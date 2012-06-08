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
	/// <summary>
	/// FoodTest 的摘要说明
	/// </summary>
	[TestClass]
	public class FoodTest
	{
		private FoodData _food;
		public FoodTest()
		{
			//
			//TODO: 在此处添加构造函数逻辑
			//
			_food = new FoodData();
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
		/// 测试获取所有食物列表
		/// </summary>
		[TestMethod]
		public void GetAllFoodTest()
		{
			//
			// TODO: 在此处添加测试逻辑
			//
			IList<Food> allfood = _food.GetAllFood();
			Assert.AreEqual(allfood.Count, 10);
		}

		/// <OrderQuery>
		/// 通过食物名字查询所有满足条件的食物Food对象的列表
		/// </OrderQuery>
		[TestMethod]
		public void GetFoodByNameTest()
		{
			IList<Food> foodbyname = _food.GetFoodByName("鱼香茄子");
			Assert.AreEqual(1, foodbyname.Count);
			Assert.AreEqual("川菜", foodbyname.First().FoodType);
		}

		/// <summary>
		/// 通过食物类型查询所有满足条件的食物Food对象的列表
		/// </summary>
		[TestMethod]
		public void GetFoodByTypeTest()
		{
			IList<Food> foodtype = _food.GetFoodByFoodType("快餐");
			Assert.AreEqual(2, foodtype.Count);
		}

		/// <Create>
		/// 通过传入Food对象，创建Food写进数据库，进行测试
		/// </Create>
		/*[TestMethod]
		public void CreateFoodTest()
		{
			var tempFood = new Food
			{
				FoodName = "抹茶蛋糕",
				FoodPrice = 4,
				FoodType = "甜点",
				FoodContent = "抹茶蛋糕就是加了抹茶粉的蛋糕。抹茶蛋糕既美观又美味，是一种很受人们喜爱的蛋糕。"
			};
			int id = _food.CreateFood(tempFood);
			var testFood = _food.GetFoodById(id);
			Assert.IsNotNull(testFood);
		}*/
	}
}
