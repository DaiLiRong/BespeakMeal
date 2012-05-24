﻿using System;
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
		public void CreateUser(User userInfo)
		{
			Session.Save(userInfo);
			Session.Flush();
		}
		public User GetUserById(int userId)
		{
			return Session.Get<User>(userId);
		}
	}
}
