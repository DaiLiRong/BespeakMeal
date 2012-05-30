﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Data
{
	public class FoodData
	{
		protected ISession Session { get; set; }
		public FoodData(ISession session)
		{
			Session = session;
		}

		#region tbl_food表的CURD操作

		/// <Create>
		/// 通过传入Food对象，创建Food写进数据库
		/// </Create>
		/// <param name="foodInfo"></param>
		/// <returns></returns>
		public int CreateFood(Food foodInfo)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					int newid = (int)Session.Save(foodInfo);
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
		/// 通过FoodId获取Food对象
		/// </Query>
		/// <param name="foodId"></param>
		/// <returns></returns>
		public Food GetFoodById(int foodId)
		{
			return Session.Get<Food>(foodId);
		}

		/// <Query>
		/// 通过FoodName（食物名字）获取Food对象
		/// </Query>
		/// <param name="foodId"></param>
		/// <returns></returns>
		public IList<Food> GetFoodByName(string foodName)
		{
			return Session.CreateQuery("from Food where FoodName = :fn")
				.SetString("fn", foodName)
				.List<Food>();
		}

		/// <Query>
		/// 通过FoodType(食物类型，如粤菜、川菜、酒水、点心等)获取Food对象列表
		/// </Query>
		/// <param name="foodId"></param>
		/// <returns></returns>
		public IList<Food> GetFoodByFoodType(string foodType)
		{
			return Session.CreateQuery("from Food where FoodType = :ft")
				.SetString("ft", foodType)
				.List<Food>();
		}


		#endregion
	}
}