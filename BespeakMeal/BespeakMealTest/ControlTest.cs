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
		private OrderFoodControl _orderFoodControl = new OrderFoodControl();
		private UserControl1 _userControl = new UserControl1();
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

		/// <summary>
		/// 测试：将OrderFood的IList表转换成FoodItem的IList表
		/// OrderFood（OrderFoodId、OrderId、FoodId、FoodNum）
		/// OrderItem（FoodId、食物名字、单价、数量、总价）
		/// </summary>
		[TestMethod]
		public void GetFoodItemByOrderFoodListTest()
		{
			IList<OrderFood> orderfoodlist = new List<OrderFood>();
			IList<FoodItem> fooditemlist = new List<FoodItem>();
			
			OrderFood of = new OrderFood
			{
				FoodId = 1,
				OrderId = 2,
				FoodNum = 2
			};
			orderfoodlist.Add(of);
			fooditemlist = _orderControl.GetFoodItemByOrderFoodList(orderfoodlist);
			Assert.AreEqual(fooditemlist.First().FoodName, "鱼香茄子");
		}

		/// <summary>
		/// 修改订单食物份数
		/// </summary>
		[TestMethod]
		public void ModifyFoodNumTest()
		{
			_orderFoodControl.ModifyFoodNum(1, 1, 100);
			int foodnum = _orderFood.GetOrderFoodByOrderIdAndFoodId(8, 1).First().FoodNum;
			Assert.AreEqual(foodnum, 100);
		}

		/// <summary>
		/// 删除购物车中一条食物
		/// </summary>
		[TestMethod]
		public void DeleteOrderFoodTest()
		{
			int orderid = 8;
			int foodid = 1;
			_orderFoodControl.DeleteOrderFood(orderid, foodid);
			IList<OrderFood> orderfood = _orderFood.GetOrderFoodByOrderIdAndFoodId(orderid, foodid);
			Assert.AreEqual(orderfood.Count, 0);
		}

		/// <summary>
		/// 修改密码测试
		/// </summary>
		[TestMethod]
		public void ChangePasswordTest()
		{
			string password = "1234";
			_userControl.ChangePassword(1, password);
			User u = _user.GetUserById(1);
			Assert.AreEqual(u.Password,password);
		}

		/// <summary>
		/// 提交订单测试
		/// </summary>
		[TestMethod]
		public void SubmitOrderTest()
		{
			_orderControl.SubmitOrder(1,"","","");
			IList<Order> productcar = _order.GetOrderInProductCar(1);
			Assert.AreEqual(0, productcar.Count);
		}

		/// <summary>
		/// 日期统计销售额测试
		/// </summary>
		[TestMethod]
		public void StatisticTest()
		{
			Statistic st = new Statistic(new DateTime(2012, 6, 14));
			Assert.AreEqual(st.Total, 79);
			//Assert.AreEqual(st.OrderTime, "2012/6/14");
			Assert.AreEqual(st.Date, "2012-6-14");
			Assert.AreEqual(st.Hour, "0");
			Assert.AreEqual(st.Minute, "0");
		}

		/// <summary>
		/// 获得所有管理订单项，对第一个订单项进行各个字段测试
		/// </summary>
		[TestMethod]
		public void GetAllOrderItemTest()
		{
			IList<ManagerOrderItem> moilist = _orderControl.GetAllOrderItem();

			Assert.AreEqual(moilist.Count, 17);
			ManagerOrderItem first = moilist.First();

			Assert.AreEqual(first.OrderId, 4);
			Assert.AreEqual(first.UserId, 1);
			Assert.AreEqual(first.UserName, "lion");
			Assert.AreEqual(first.Address, "前山路206号");
			Assert.AreEqual(first.FoodNum, 0);
			Assert.AreEqual(first.FoodList.Count, 0);
			Assert.AreEqual(first.Status, "订单已取消");
		}

	}
}
