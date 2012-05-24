using System;
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
		private UserData _user;
		private ISession _session;

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

		[TestMethod]
		public void TestUser()
		{
			/*var tempUser = new User { UserName = "lion", Password = "123", 
				FirstName = "戴", LastName = "礼荣", Gender = '男', PhoneNum = "12345678901", Email = "xhyzdai@qq.com" };*/
			_session = new NHibernateHelper().GetSession();
			_user = new UserData(_session);
			//_user.CreateUser(tempUser);
			User userInfo = _user.GetUserById(1);
			string userName = userInfo.FirstName;
			Assert.AreEqual("礼荣", userName);
		}
	}
}
