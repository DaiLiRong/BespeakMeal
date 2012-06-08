using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Data
{
	public class OrderFoodData
	{
		protected ISession Session { get; set; }
		public OrderFoodData(ISession session)
		{
			Session = session;
		}
		public OrderFoodData()
		{
			Session = new NHibernateHelper().GetSession();
		}
		#region tbl_orderfood表的CURD操作

		/// <summary>
		/// 创建订单食物
		/// </summary>
		/// <param name="orderfood"></param>
		/// <returns></returns>
		public int CreateOrderFood(OrderFood orderfood)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					int orderfoodid = (int)Session.Save(orderfood);
					Session.Flush();
					tx.Commit();
					return orderfoodid;
				}
				catch (HibernateException)
				{
					tx.Rollback();
					return -1;
					throw;
				}
			}
		}


		/// <Query>
		/// 通过订单ID获取该订单的食物列表
		/// </Query>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public IList<OrderFood> GetOrderFoodListByOrderId(int orderId)
		{
			return Session.CreateQuery("from OrderFood where orderId = :id")
				.SetInt32("id", orderId)
				.List<OrderFood>();
		}

		/// <summary>
		/// 通过OrderFood的Id获取Food对象
		/// </summary>
		/// <param name="orderFoodId"></param>
		/// <returns></returns>
		public Food GetOrderFoodById(int orderFoodId)
		{
			return Session.Get<Food>(orderFoodId);
		}

		/// <summary>
		/// 通过OrderId和FoodId返回OrderFood，看是否已经购买相同的商品
		/// </summary>
		/// <param name="orderid"></param>
		/// <param name="foodid"></param>
		/// <returns></returns>
		public IList<OrderFood> GetOrderFoodByOrderIdAndFoodId(int orderid, int foodid)
		{
			return Session.CreateQuery("from OrderFood where OrderId=:orderid and FoodId=:foodid")
				.SetInt32("orderid", orderid)
				.SetInt32("foodid", foodid)
				.List<OrderFood>();
		}

		/// <summary>
		/// 通过OrderId和FoodId得到OrderFood，增加食物份数num份
		/// </summary>
		/// <param name="orderid"></param>
		/// <param name="foodid"></param>
		/// <param name="num"></param>
		public void AddFoodNum(int orderid, int foodid, int num)
		{
			//获取订单食物OrderFood，然后修改它的份数，写入到数据库
			OrderFood orderfood = this.GetOrderFoodByOrderIdAndFoodId(orderid, foodid).First();
			orderfood.FoodNum += num;
			this.UpdateOrderFood(orderfood);
		}

		/// <summary>
		/// 通过传入OrderFood对象，修改、更新数据库信息
		/// </summary>
		/// <param name="orderfood"></param>
		public void UpdateOrderFood(OrderFood orderfood)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Update(orderfood);
					Session.Flush();
					tx.Commit();
				}
				catch (HibernateException)
				{
					tx.Rollback();
					throw;
				}
			}
		}
		#endregion
	}
}
