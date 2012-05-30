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

		#region tbl_orderfood表的CURD操作

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

		public OrderFood GetOrderFoodById(int orderFoodId)
		{
			return Session.Get<OrderFood>(orderFoodId);
		}

		#endregion
	}
}
