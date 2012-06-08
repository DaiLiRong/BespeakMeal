using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
namespace BespeakMeal
{
	/// <summary>
	/// 对逻辑层的测试，包括用户加入购物车的测试，获取购物车食物，删除食物、购物车、订单的测试
	/// </summary>
	[TestClass]
	public class ControlTest
	{
		private ISession _session;
		private UserData _user;
		private OrderData _order;
		private FoodData _food;
		private OrderFoodData _orderFood;
		private OrderControl _orderControl = new OrderControl();
		public ControlTest()
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

		/// <summary>
		/// 点击食物，往购物车中添加条目
		/// </summary>
		[TestMethod]
		public void ProductCarAddFoodTest()
		{
			//UserId，FoodId，添加食物
			//Id为2的用户，Id为7的食物，食物加入用户购物车
			int userid = 2, foodid = 7;
			_orderControl.ProductCarAddFood(userid, foodid);

			//下面为验证
			IList<Order> orderlist = _order.GetOrderInProductCar(userid);
			Assert.AreNotEqual(0, orderlist);
			if (orderlist.Count != 0)//说明用户有购物车了（未下单的订单）
			{
				int orderid = orderlist.First().OrderId;
				int orderfoodnum = _orderFood.GetOrderFoodByOrderIdAndFoodId(orderid, foodid).First().FoodNum;
				Assert.AreNotEqual(0, orderfoodnum);
			}

			//int orderfoodnum = _orderFood.GetOrderFoodByOrderIdAndFoodId(9, 3).First().FoodNum;
			//Assert.AreEqual(1, orderfoodnum);
		}

		/// <summary>
		/// 测试：用userid获取用户购物车所有订单食物OrderFood对象
		/// </summary>
		[TestMethod]
		public void GetProductCarFoodListTest()
		{
			int userid = 2;
			IList<OrderFood> orderfoodlist = _orderControl.GetProductCarFoodList(userid);
			Assert.AreEqual(orderfoodlist.Count, 1);
			Assert.AreEqual(orderfoodlist.First().FoodId, 7);
			Assert.AreEqual(orderfoodlist.First().FoodNum, 2);
		}
	}
}
