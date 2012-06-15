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
	public class OrderTest
	{
		private ISession _session;
		private UserData _user;
		private OrderData _order;
		private FoodData _food;
		private OrderFoodData _orderFood;
		public OrderTest()
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

		/// <Query>
		/// 通过UserId获取Order集，测试个数是否正确
		/// </Query>
		[TestMethod]
		public void GetOrderByUserIdTest()
		{
			IList<Order> orders = _order.GetOrdersByUserId(1);
			Assert.AreEqual(orders.Count, 4);
		}

		/// <OrderQuery>
		/// 通过订单状态查询所有处于某个状态的订单列表，如历史订单(2)、新订单(1)、失效订单(0)
		/// </OrderQuery>
		[TestMethod]
		public void TestOrderStatus()
		{
			IList<Order> neworders = _order.GetNewOrder();
			IList<Order> historyorders = _order.GetHistoryOrder();
			IList<Order> disabledorders = _order.GetDisabledOrder();
			Assert.AreEqual(4, neworders.Count);
			Assert.AreEqual(0, historyorders.Count);
			Assert.AreEqual(0, disabledorders.Count);
		}

		[TestMethod]
		public void GetOrdersByUserIdTest()
		{
			IList<Order> tempOrders = _order.GetOrdersByUserId(1);
			Assert.AreEqual(4, tempOrders.Count);
		}

		/// <summary>
		/// 测试获取购物车生成的订单
		/// </summary>
		[TestMethod]
		public void GetOrderInProductCarTest()
		{
			IList<Order> tempOrders = _order.GetOrderInProductCar(1);
			Assert.AreEqual(1, tempOrders.Count);
		}

		/// <summary>
		/// 获取所有订单测试个数
		/// </summary>
		[TestMethod]
		public void GetAllOrderTest()
		{
			IList<Order> tempOrders = _order.GetAllOrder();
			Assert.AreEqual(tempOrders.Count, 17);
		}

		/// <summary>
		/// 获取当天的销售额
		/// </summary>
		[TestMethod]
		public void GetTodayTotalTest()
		{
			double total = _order.GetTodayTotal(new DateTime(2012, 6, 14));
			Assert.AreEqual(total, 79.0);
		}

		/// <summary>
		/// 通过传入Order对象，创建Order写进数据库，进行测试
		/// </summary>
		/*[TestMethod]
		public void CreateOrderTest()
		{
			//IList<Food> tempFoodList = null;
			//tempFoodList.Add(_food.GetFoodById(1));
			var tempOrder = new Order
			{
				User = _user.GetUserById(1),
				OrderTime = DateTime.Now,
				EatType = "外卖",
				Address = "暨大北门",
				Foods = new List<Food> { _food.GetFoodById(1), _food.GetFoodById(2) },
			};

			int id = _order.CreateOrder(tempOrder);
			var testOrder = _order.GetOrderById(id);
			Assert.IsNotNull(testOrder);
		}*/
	}
}
