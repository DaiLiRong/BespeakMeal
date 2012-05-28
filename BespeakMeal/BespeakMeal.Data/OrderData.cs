using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Data
{
	public class OrderData
	{
		protected ISession Session { get; set; }
		public OrderData(ISession session)
		{
			Session = session;
		}

		#region TBL_User表的CURD操作
		/// <Create>
		/// 通过传入Order对象，创建Order写进数据库
		/// </Create>
		/// <param name="orderInfo"></param>
		/// <returns></returns>
		public int CreateOrder(Order orderInfo)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					int newid = (int)Session.Save(orderInfo);
					Session.Flush();
					tx.Commit();
					return newid;
				}
				catch (HibernateException)
				{
					tx.Rollback();
					throw;
				}
			}
		}

		/// <Query>
		/// 通过OrderId获取Order对象
		/// </Query>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public Order GetOrderById(int orderId)
		{
			return Session.Get<Order>(orderId);
		}

		#endregion
	}
}
