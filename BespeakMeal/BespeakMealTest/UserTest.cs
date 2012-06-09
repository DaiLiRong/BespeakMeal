using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
namespace UserTest
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
			string userName = userInfo.Name;
			Assert.AreEqual("礼荣", userName);
		}

		/// <Query>
		/// 通过名字Firstname获取User对象，测试字段是否正确
		/// </Query>
		[TestMethod]
		public void GetUserByFirstnameTest()
		{
			IList<User> uuser = _user.GetUserByName("礼荣");
			Assert.AreEqual(1, uuser.Count);
			foreach (var c in uuser)
			{
				Assert.AreEqual("礼荣", c.Name);
			}
		}

		/// <summary>
		/// 测试用户名、密码，以确定是否登录成功
		/// </summary>
		[TestMethod]
		public void TestLogin()
		{
			bool result = _user.CorrectNamePassword("lion", "123");
			Assert.IsTrue(result);
		}

		/// <summary>
		/// 测试：通过名字查询是否存在用户
		/// </summary>
		[TestMethod]
		public void UserExistTest()
		{
			bool userexist1 = _user.UserExist("lion");
			bool userexist2 = _user.UserExist("luo");
			Assert.IsTrue(userexist1);
			Assert.IsFalse(userexist2);
		}



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
	}
}
