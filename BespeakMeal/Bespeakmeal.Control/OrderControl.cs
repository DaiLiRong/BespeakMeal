using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Control
{
	public class OrderControl
	{
		private OrderFoodData _orderfood = new OrderFoodData();
		private OrderData _order = new OrderData();
		private FoodData _food = new FoodData();
		private UserData _user = new UserData();
		public OrderControl()
		{
		}

		/// <summary>
		/// 要判断是否存在购物车，然后调用PutInCar函数将食物放进购物车中（数据库）
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="foodid"></param>
		/// <returns></returns>
		public void ProductCarAddFood(int userid, int foodid)
		{
			IList<Order> orderlist=_order.GetOrderInProductCar(userid);

			//不存在购物车就先创建一个购物车
			if (orderlist.Count == 0)
			{
				//创建一个购物车（订单状态status为0）
				Order order = new Order
				{
					UserId = userid,
					status = 0,
					OrderTime = DateTime.Now
				};
				int orderid = _order.CreateOrder(order);

				//将商品放入购物车
				PutInCar(orderid, foodid);
			}
			else//已经存在购物车，就将商品放入购物车
			{
				int orderid = orderlist.First().OrderId;
				PutInCar(orderid, foodid);
			}
		}

		/// <summary>
		/// 将食物放入购物车中
		/// </summary>
		/// <param name="orderid"></param>
		/// <param name="foodid"></param>
		private void PutInCar(int orderid, int foodid)
		{
			IList<OrderFood> of =  _orderfood.GetOrderFoodByOrderIdAndFoodId(orderid, foodid);
			if (of.Count > 0)
			{
				//已经存在食物，将数量加1
				_orderfood.AddFoodNum(orderid, foodid, 1);
			}
			else
			{
				//购物车中不存在食物，新增一个食物到数据库中
				OrderFood orderfood = new OrderFood
				{
					OrderId = orderid,
					FoodId = foodid,
					FoodNum = 1
				};
				_orderfood.CreateOrderFood(orderfood);
			}
		}

		/// <summary>
		///  通过userid返回用户购物车里面的订单食物OrderFood对象
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		public IList<OrderFood> GetProductCarFoodList(int userid)
		{
			//通过userid获取购物车订单
			IList<Order> order = _order.GetOrderInProductCar(userid);
			int orderid = 0;
			//购物车订单不为空，说明存在至少一个食物
			if (order.Count != 0)
			{
				orderid = order.First().OrderId;
			}
			return _orderfood.GetOrderFoodListByOrderId(orderid);
		}

		/// <summary>
		/// 传入OrderFood对象（OrderId、FoodId、FoodNum）列表
		/// 返回食物图片（FoodId）、食物名字、单价、数量、总价
		/// </summary>
		/// <param name="orderfoodlist"></param>
		/// <returns></returns>
		public IList<FoodItem> GetFoodItemByOrderFoodList(IList<OrderFood> orderfoodlist)
		{
			IList<FoodItem> fooditemlist = new List<FoodItem>();
			foreach(var v in orderfoodlist)
			{
				int foodid = v.FoodId;
				string foodname = _food.GetFoodById(v.FoodId).FoodName;
				int foodnum = v.FoodNum;
				double foodprice = _food.GetFoodById(v.FoodId).FoodPrice;
				double moneycount = foodnum * foodprice;
				int orderid = v.OrderId;
				//要放在循环里面new，因为List的Add仅仅保存它的指针，放在外面的话，所有的对象都是指向同一个内存空间
				FoodItem fooditem = new FoodItem();
				//给FoodItem的各个字段赋值
				fooditem.FoodId = foodid;
				fooditem.FoodName = foodname;
				fooditem.FoodNum = foodnum;
				fooditem.FoodPrice = foodprice;
				fooditem.MoneyCount = moneycount;
				fooditem.OrderId = orderid;
				fooditemlist.Add(fooditem);
			}
			return fooditemlist;
		}

		/// <summary>
		/// 提交订单，将订单状态改为1
		/// </summary>
		/// <param name="userid"></param>
		public int SubmitOrder(int userid, string address, string phonenum, string otherreq)
		{
			IList<Order> orderlist = _order.GetOrderInProductCar(userid);
			if (0 != orderlist.Count)
			{
				Order order = orderlist.First();
				//状态1为已下单的状态
				order.status = 1;
				order.Address = address;
				order.PhoneNum = phonenum;
				order.OtherRequest = otherreq;
				_order.UpdateOrder(order);
				return order.OrderId;
			}
			return -1;
		}

		/// <summary>
		/// 通过userid返回订单列表，订单类型为OrderItem，包含订单编号，下单时间，食物份数，总金额，其他要求，订单状态
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		public IList<OrderItem> GetOrderItemListByUserId(int userid)
		{
			IList<Order> orderlist = _order.GetOrdersByUserId(userid);
			IList<OrderItem> orderitemlist = new List<OrderItem>();			
			foreach(var v in orderlist)
			{
				DateTime d = v.OrderTime;
				string orderreference = d.Year.ToString() + d.Month.ToString() + d.Day.ToString() +
					d.Hour.ToString() + d.Minute.ToString() + d.Second.ToString() + "-" + v.OrderId.ToString();
				DateTime ordertime = v.OrderTime;
				int foodnum = _orderfood.GetFoodNumByOrderId(v.OrderId);
				double total = _orderfood.GetTotalByOrderId(v.OrderId);
				string otherreq = v.OtherRequest;
				string status = "";
				switch (v.status)
				{
					case 1:
						status = "未付款";
						break;
					case 2:
						status = "已付款";
						break;
					case 3:
						status = "交易成功";
						break;
					case -1:
						status = "订单已取消";
						break;
				}

				//要放在循环里面new，因为List的Add仅仅保存它的指针，放在外面的话，所有的对象都是指向同一个内存空间
				OrderItem oi = new OrderItem();
				oi.OrderReference = orderreference;
				oi.OrderId = v.OrderId;
				oi.OrderTime = ordertime;
				oi.FoodNum = foodnum;
				oi.Total = total;
				oi.OtherReq = otherreq;
				oi.Status = status;
				orderitemlist.Add(oi);
			}
			return orderitemlist;
		}

		/// <summary>
		/// 取消订单，status变为-1
		/// </summary>
		/// <param name="orderid"></param>
		public void CancelOrderByOrderId(int orderid)
		{
			Order order = _order.GetOrderById(orderid);
			order.status = -1;
			_order.UpdateOrder(order);
		}

		/// <summary>
		/// 确认订单，status变为3
		/// </summary>
		/// <param name="orderid"></param>
		public void ConfirmOrderByOrderId(int orderid)
		{
			Order order = _order.GetOrderById(orderid);
			order.status = 3;
			_order.UpdateOrder(order);
		}

		/// <summary>
		/// 订单付款，status变为2
		/// </summary>
		/// <param name="orderid"></param>
		public void PayOrderByOrderId(int orderid)
		{
			Order order = _order.GetOrderById(orderid);
			order.status = 2;
			_order.UpdateOrder(order);			
		}
	}
}
