using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Data
{
	public class UserData
	{		
		protected ISession Session { get; set; }
		public UserData(ISession session)
		{
			Session = session;
		}
		public UserData()
		{
			Session = new NHibernateHelper().GetSession();
		}

		#region TBL_User表的CURD操作
		/// <Create>
		/// 通过传入User对象，创建User写进数据库
		/// </Create>
		public int CreateUser(User userInfo)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					int newid = (int)Session.Save(userInfo);
					Session.Flush();
					tx.Commit();
					return newid;
				}
				catch (HibernateException)
				{
					tx.Rollback();
					return -1;
					throw;
				}
			}
		}

		public IList<User> GetAllUser()
		{
			return Session.CreateQuery("from User")
				.List<User>();
		}

		/// <Query>
		/// 通过UserId获取User对象
		/// </Query>
		public User GetUserById(int userId)
		{
			return Session.Get<User>(userId);
		}

		/// <Query>
		/// 通过UserName获取User对象
		/// </Query>
		public IList<User> GetUserByUserName(string userName)
		{
			return Session.CreateQuery("from User u where u.UserName=:un")
				.SetString("un", userName)
				.List<User>();
		}

		/// <summary>
		/// 传入用户名，判读是否用户名是否已经存在
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public bool UserExist(string userName)
		{
			if (GetUserByUserName(userName).Count > 0)
			{
				return true;
			}
			else
				return false;
		}

		/// <Query>
		/// 通过名字Name获取User对象
		/// </Query>
		public IList<User> GetUserByName(string name)
		{
			return Session.CreateQuery("from User u where u.Name=:fn")
				.SetString("fn",name)
				.List<User>();
		}

		/// <summary>
		/// 用户名密码检查用户登录
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public bool CorrectNamePassword(string username, string password)
		{
			IList<User> result=Session.CreateQuery("from User u where u.UserName=:un and u.Password=:pw")
				.SetString("un", username).SetString("pw", password)
				.List<User>();
			if (0 == result.Count)
				return false;
			else
				return true;
		}

		/// <Delete>
		/// 通过User删除数据库中的项
		/// </Delete>
		public void DeleteUser(User user)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Delete(user);
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

		/// <Update>
		/// 通过传入User对象，修改、更新数据库信息
		/// </Update>
		public void UpdateUser(User user)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Update(user);
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

		/// <SaveOrUpdate>
		/// IList保存的User对象中，是否应该更新字段还是将整个对象保存到数据库中
		/// </SaveOrUpdate>
		public void SaveOrUpdateUser(IList<User> user)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					foreach (var u in user)
					{
						Session.SaveOrUpdate(u);
					}
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
		/// 通过UserId获取用户所有订单
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		/*public IList<Order> GetOrdersByUserId(int userId)
		{
			return Session.Get<IList<Order>>(userId);
			//return Session.CreateQuery("select Orders from User u where u.UserId = :userId")
			//	.SetInt32("userId", userId)
			//	.List<Order>();
		}*/

		/*public IList<User> GetUsersWithOrders(DateTime orderTime)
		{
			return Session.CreateQuery("select distinct u from User u inner join u.Orders o where o.OrderTime > :orderTime")
				.SetDateTime("orderTime", orderTime).List<User>();
		}*/

		#endregion
	}
}
