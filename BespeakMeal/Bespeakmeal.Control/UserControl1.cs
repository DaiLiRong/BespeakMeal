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
	public class UserControl1
	{
		private OrderFoodData _orderfood = new OrderFoodData();
		private OrderData _order = new OrderData();
		private FoodData _food = new FoodData();
		private UserData _user = new UserData();
		public UserControl1()
		{
		}

		public void ChangePassword(int userid, string password)
		{
			User u = _user.GetUserById(userid);
			u.Password = password;
			_user.UpdateUser(u);
		}
	}
}
