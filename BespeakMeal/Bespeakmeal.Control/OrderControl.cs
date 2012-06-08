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
	}
}
