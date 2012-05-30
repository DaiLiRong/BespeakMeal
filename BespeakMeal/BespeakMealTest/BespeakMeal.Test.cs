﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Test
{
	[TestClass]
	public class BespeakMealTest
	{
		private ISession _session;
		private UserData _user;
		private OrderData _order;
		private FoodData _food;
		private OrderFoodData _orderFood;

		public BespeakMealTest()
		{
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
		/// 通过UserId获取User对象，测试字段是否正确
		/// </Query>
		[TestMethod]
		public void GetUserByIdTest()
		{
			User userInfo = _user.GetUserById(1);
			string userName = userInfo.FirstName;
			Assert.AreEqual("礼荣", userName);
		}

		/// <Query>
		/// 通过名字Firstname获取User对象，测试字段是否正确
		/// </Query>
		[TestMethod]
		public void GetUserByFirstnameTest()
		{
			IList<User> uuser = _user.GetUserByFirstname("礼荣");
			Assert.AreEqual(1, uuser.Count);
			foreach (var c in uuser)
			{
				Assert.AreEqual("礼荣", c.FirstName);
			}
		}

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

		/// <OrderQuery>
		/// 通过食物名字、类型查询所有满足条件的食物Food对象的列表
		/// </OrderQuery>
		[TestMethod]
		public void GetFoodByNameTest()
		{
			IList<Food> foodbyname = _food.GetFoodByName("鱼香茄子");
			IList<Food> foodbytype = _food.GetFoodByFoodType("粤菜");
			Assert.AreEqual(1, foodbyname.Count);
			Assert.AreEqual(1, foodbytype.Count);
			Assert.AreEqual("川菜", foodbyname.First().FoodType);
			Assert.AreEqual("梅菜扣肉", foodbytype.First().FoodName);
		}

		/// <OrderFoodQuery>
		/// 通过订单ID获取食物列表的测试
		/// </OrderFoodQuery>
		[TestMethod]
		public void GetFoodListByOrderIdTest()
		{
			IList<OrderFood> foodlist = _orderFood.GetOrderFoodListByOrderId(8);
			Assert.AreEqual(2, foodlist.Count);
		}

		/*[TestMethod]
		public void GetOrdersByUserIdTest()
		{
			IList<Order> tempOrders = _user.GetOrdersByUserId(1);
			Assert.AreEqual(4, tempOrders.Count);
		}*/

		/*[TestMethod]
		public void GetUserByOrderIdTest()
		{
			User user = _order.GetUserByOrderId(4);
			Assert.IsNotNull(user);
			//Assert.AreEqual("lion", user.UserName);
		}*/
		/*[TestMethod]
		public void GetUserWithOrdersTest()
		{
			IList<User> users = _user.GetUsersWithOrders(new DateTime(2008, 10, 1));
			//Assert.AreEqual(1, users.Count<User>);
			Assert.IsNotNull(users);
			Assert.AreEqual(users.First().FirstName, "礼荣");
			foreach (User u in users)
			{
				foreach (Order o in u.Orders)
				{
					//DateTime tempDateTime = new DateTime(2013, 10, 1);
					//bool tempBool = false;
					//if (o.OrderTime > tempDateTime)
					//    tempBool = true;
					//Assert.IsTrue(tempBool);
				}
			}
			foreach (User c in users)
			{
				Assert.AreEqual(2, users.Count<User>(x => x == c));
			}
		}*/

		/// <Create>
		/// 通过传入User对象，创建User写进数据库，进行测试
		/// </Create>
		/*[TestMethod]
		public void CreateUserTest()
		{
			var tempUser = new User
			{
				UserName = "test",
				Password = "123",
				FirstName = "阿飞",
				LastName = "放假",
				Gender = '男',
				PhoneNum = "12345678901",
				Email = "luo@qq.com",
				CreateTime = DateTime.Now,
				SuperUser = 0,
				Status = 0
			};
			int id = _user.CreateUser(tempUser);
			var testUser = _user.GetUserById(id);
			Assert.IsNotNull(testUser);
		}*/

		/// <Delete>
		/// 通过UserId删除数据库中Id号跟User的Id一样的项
		/// </Delete>
		/*[TestMethod]
		public void DeleteUserTest()
		{
			var user = _user.GetUserById(5);
			_user.DeleteUser(user);
			var testUser = _user.GetUserById(5);
			Assert.IsNull(testUser);
		}*/

		/// <Update>
		/// 通过传入User对象，修改、更新数据库信息
		/// </Update>
		/*[TestMethod]
		public void UpdateUserTest()
		{
			var user = _user.GetUserById(2);
			user.FirstName = "彩娟";
			user.LastName = "罗";
			_user.UpdateUser(user);
			var testUser = _user.GetUserById(2);
			Assert.AreEqual("彩娟", user.FirstName);
		}*/

		/// <SaveOrUpdate>
		/// IList保存的User对象中，是否应该更新字段还是将整个对象保存到数据库中
		/// </SaveOrUpdate>
		/*[TestMethod]
		public void SaveOrUpdateUserTest()
		{
			IList<User> users = _user.GetUserByFirstname("彩娟");
			foreach (var c in users)
			{
				c.FirstName = "娟";
			}
			var c1 = new User() { Email = "1", Gender = '女', FirstName = "娟", LastName = "1", Password = "1", UserName = "1", PhoneNum = "1" };
			users.Add(c1);

			_user.SaveOrUpdateUser(users);

			int testListCount = _user.GetUserByFirstname("娟").Count;
			Assert.AreEqual(users.Count, testListCount);
		}*/

		/// <Create>
		/// 通过传入Order对象，创建Order写进数据库，进行测试
		/// </Create>
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

		/// <Create>
		/// 通过传入Food对象，创建Food写进数据库，进行测试
		/// </Create>
		/*[TestMethod]
		public void CreateFoodTest()
		{
			var tempFood = new Food
			{
				FoodName = "梅菜扣肉",
				FoodPrice = 11.0,
				FoodType = "粤菜",
				FoodContent = "梅菜扣肉即我们常称之烧白，因地域不同而名字颇多，其特点在于颜色酱红油亮，汤汁黏稠鲜美，扣肉滑溜醇香，肥而不腻，食之软烂醇香。"
			};
			int id = _food.CreateFood(tempFood);
			var testFood = _food.GetFoodById(id);
			Assert.IsNotNull(testFood);
		}*/
	}
}
