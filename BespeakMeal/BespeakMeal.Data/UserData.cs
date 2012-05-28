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
					throw;
				}
			}
		}

		/// <Query>
		/// 通过UserId获取User对象
		/// </Query>
		public User GetUserById(int userId)
		{
			return Session.Get<User>(userId);
		}

		/// <Query>
		/// 通过名字Firstname获取User对象
		/// </Query>
		public IList<User> GetUserByFirstname(string firstname)
		{
			return Session.CreateQuery("from User u where u.FirstName=:fn")
				.SetString("fn",firstname)
				.List<User>();
		}

		/// <Delete>
		/// 通过UserId删除数据库中Id号跟User的Id一样的项
		/// </Delete>
		public void DeleteUser(User user)
		{
			Session.Delete(user);
			Session.Flush();
		}

		/// <Update>
		/// 通过传入User对象，修改、更新数据库信息
		/// </Update>
		public void UpdateUser(User user)
		{
			Session.Update(user);
			Session.Flush();
		}

		/// <SaveOrUpdate>
		/// IList保存的User对象中，是否应该更新字段还是将整个对象保存到数据库中
		/// </SaveOrUpdate>
		public void SaveOrUpdateUser(IList<User> user)
		{
			foreach (var c in user)
			{
				Session.SaveOrUpdate(c);
			}
			Session.Flush();
		}

		#endregion
	}
}
