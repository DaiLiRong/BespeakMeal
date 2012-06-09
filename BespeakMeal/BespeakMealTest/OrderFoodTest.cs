using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal
{
	[TestClass]
	public class OrderFoodTest
	{
		private ISession _session;
		private UserData _user;
		private OrderData _order;
		private FoodData _food;
		private OrderFoodData _orderFood;
		public OrderFoodTest()
		{
			//
			//TODO: 在此处添加构造函数逻辑
			//
			_session = new NHibernateHelper().GetSession();
			_order = new OrderData(_session);
			_user = new UserData(_session);
			_food = new FoodData(_session);
			_orderFood = new OrderFoodData(_session);
		}

		#region 附加测试特性
		//
		// 编写测试时，可以使用以下附加特性:
		//
		// 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// 在运行每个测试之前，使用 TestInitialize 来运行代码
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// 在每个测试运行完之后，使用 TestCleanup 来运行代码
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		/// <OrderFoodQuery>
		/// 通过订单ID获取订单食物列表的测试
		/// </OrderFoodQuery>
		[TestMethod]
		public void GetFoodListByOrderIdTest()
		{
			IList<OrderFood> foodlist = _orderFood.GetOrderFoodListByOrderId(8);
			Assert.AreEqual(2, foodlist.Count);
		}

		/// <summary>
		/// 通过OrderId和FoodId获取订单食物列表测试
		/// </summary>
		[TestMethod]
		public void GetOrderFoodByOrderIdAndFoodIdTest()
		{
			//从OrderFood表中获取orderid为8，foodid为1的订单食物
			IList<OrderFood> foodlist = _orderFood.GetOrderFoodByOrderIdAndFoodId(8, 1);
			Assert.AreEqual(1, foodlist.Count);

			//从OrderFood表中获取orderid为8，foodid为2的订单食物
			foodlist = _orderFood.GetOrderFoodByOrderIdAndFoodId(8, 2);
			Assert.AreEqual(1, foodlist.Count);

			//从OrderFood表中获取orderid为1，foodid为2的订单食物
			foodlist = _orderFood.GetOrderFoodByOrderIdAndFoodId(1, 2);
			Assert.AreEqual(0, foodlist.Count);
		}

		/// <summary>
		/// 测试通过OrderId和FoodId增加订单食物份数
		/// </summary>
		/*[TestMethod]
		public void AddFoodNumTest()
		{
			_orderFood.AddFoodNum(8, 1, 1);
			OrderFood orderfood = _orderFood.GetOrderFoodByOrderIdAndFoodId(8, 1).First();
			Assert.AreEqual(orderfood.FoodNum, 2);
		}*/


	}
}
