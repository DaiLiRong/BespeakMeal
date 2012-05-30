﻿using System;
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

		#region TBL_Order表的CURD操作
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

		/// <Query>
		/// 通过UserId获取Order集，可以测试个数是否正确
		/// </Query>
		public IList<Order> GetOrdersByUserId(int userId)
		{
			return Session.CreateQuery("from Order where UserId = :userId")
				.SetInt32("userId", userId)
				.List<Order>();
		}

		/// <Query>
		/// 返回新订单，status为1的订单
		/// </Query>
		public IList<Order> GetNewOrder()
		{
			return Session.CreateQuery("from Order where status = :st")
				.SetInt32("st", 1)
				.List<Order>();
		}

		/// <Query>
		/// 返回历史订单（交易成功），status为2的订单
		/// </Query>
		public IList<Order> GetHistoryOrder()
		{
			return Session.CreateQuery("from Order where status = :st")
				.SetInt32("st", 2)
				.List<Order>();
		}

		/// <Query>
		/// 返回失效订单（交易失败的），status为0的订单
		/// </Query>
		public IList<Order> GetDisabledOrder()
		{
			return Session.CreateQuery("from Order where status = :st")
				.SetInt32("st", 0)
				.List<Order>();
		}
		
		
		
		/*public User GetUserByOrderId(int orderId)
		{
			return Session.Get<User>(orderId);
		}*/

		#endregion
	}
}
