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
	public class OrderFoodControl
	{
		private OrderFoodData _orderfood = new OrderFoodData();
		private OrderData _order = new OrderData();
		private FoodData _food = new FoodData();
		private UserData _user = new UserData();
		public OrderFoodControl()
		{
		}

		/// <summary>
		/// 修改购物车食物数量
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="foodid"></param>
		public void ModifyFoodNum(int userid, int foodid, int foodnum)
		{
			IList<Order> productCarOrder = _order.GetOrderInProductCar(userid);
			int orderid = -1;
			if (productCarOrder.Count > 0)
			{
				orderid = productCarOrder.First().OrderId;
			}
			IList<OrderFood> oflist = _orderfood.GetOrderFoodByOrderIdAndFoodId(orderid, foodid);

			OrderFood orderfood = new OrderFood();
			if (oflist.Count > 0)
			{
				orderfood = oflist.First();
				orderfood.FoodNum = foodnum;
			}
			_orderfood.UpdateOrderFood(orderfood);
		}

		/// <summary>
		/// 删除购物车中id为foodid的一条食物
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="foodid"></param>
		public void DeleteOrderFood(int orderid, int foodid)
		{
			IList<OrderFood> oflist = _orderfood.GetOrderFoodByOrderIdAndFoodId(orderid, foodid);
			foreach (var v in oflist)
			{
				_orderfood.DeleteOrderFood(v);
			}
		}
	}
}
