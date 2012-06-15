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
		public OrderData()
		{
			Session = new NHibernateHelper().GetSession();
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

		/// <summary>
		/// 通过传入Order对象，删除Order
		/// </summary>
		/// <param name="orderInfo"></param>
		public void DeleteOrder(Order orderInfo)
		{		
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Delete(orderInfo);
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

		/// <summary>
		/// 获取用户购物车订单，status为0
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public IList<Order> GetOrderInProductCar(int userId)
		{
			return Session.CreateQuery("from Order where UserId = :userId and status = 0")
				.SetInt32("userId", userId)
				.List<Order>();
		}

		/// <summary>
		/// 获取当天销售额
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public double GetTodayTotal(DateTime datetime)
		{
			IList<Order> orderlist = Session.CreateQuery("from Order where status = 2 or status = 3 or status =4")
				.List<Order>();
			IList<Order> todayorder = new List<Order>();
			double total = 0;
			foreach (var v in orderlist)
			{
				if (v.PayTime.Date == datetime.Date)
					todayorder.Add(v);
			}
			foreach (var v in todayorder)
			{
				IList<OrderFood> orderfood = new OrderFoodData().GetOrderFoodListByOrderId(v.OrderId);
				foreach (var u in orderfood)
				{
					double price = new FoodData().GetFoodPriceByFoodId(u.FoodId);
					total += u.FoodNum * price;
				}
			}
			return total;
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
			return Session.CreateQuery("from Order where UserId = :userId and status != 0")
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

		/// <summary>
		/// 修改更新订单
		/// </summary>
		/// <param name="order"></param>
		public void UpdateOrder(Order order)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Update(order);
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

		/// <summary>
		/// 返回所有订单
		/// </summary>
		/// <returns></returns>
		public IList<Order> GetAllOrder()
		{
			return Session.CreateQuery("from Order where Status != 0")
				.List<Order>();
		}

		/// <summary>
		/// 返回已付款订单，status为2
		/// </summary>
		/// <returns></returns>
		public IList<Order> GetOrderByStatus(int status)
		{
			return Session.CreateQuery("from Order where Status = :status")
				.SetInt32("status", status)
				.List<Order>();
		}
	}
}
