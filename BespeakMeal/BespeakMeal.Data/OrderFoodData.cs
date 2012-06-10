using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Data
{
	public class OrderFoodData
	{
		protected ISession Session { get; set; }
		public OrderFoodData(ISession session)
		{
			Session = session;
		}
		public OrderFoodData()
		{
			Session = new NHibernateHelper().GetSession();
		}
		#region tbl_orderfood表的CURD操作

		/// <summary>
		/// 创建订单食物
		/// </summary>
		/// <param name="orderfood"></param>
		/// <returns></returns>
		public int CreateOrderFood(OrderFood orderfood)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					int orderfoodid = (int)Session.Save(orderfood);
					Session.Flush();
					tx.Commit();
					return orderfoodid;
				}
				catch (HibernateException)
				{
					tx.Rollback();
					return -1;
					throw;
				}
			}
		}

		/// <summary>
		/// 删除购物车一条食物
		/// </summary>
		/// <param name="orderfood"></param>
		public void DeleteOrderFood(OrderFood orderfood)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Delete(orderfood);
					Session.Flush();
					tx.Commit();
				}
				catch (HibernateException)
				{
					tx.Rollback();
					throw;
				}
			}
		}

		/// <Query>
		/// 通过订单ID获取该订单的食物列表
		/// </Query>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public IList<OrderFood> GetOrderFoodListByOrderId(int orderId)
		{
			return Session.CreateQuery("from OrderFood where orderId = :id")
				.SetInt32("id", orderId)
				.List<OrderFood>();
		}

		/// <summary>
		/// 通过OrderFood的Id获取Food对象
		/// </summary>
		/// <param name="orderFoodId"></param>
		/// <returns></returns>
		public Food GetOrderFoodById(int orderFoodId)
		{
			return Session.Get<Food>(orderFoodId);
		}

		/// <summary>
		/// 通过OrderId和FoodId返回OrderFood，看是否已经购买相同的商品
		/// </summary>
		/// <param name="orderid"></param>
		/// <param name="foodid"></param>
		/// <returns></returns>
		public IList<OrderFood> GetOrderFoodByOrderIdAndFoodId(int orderid, int foodid)
		{
			return Session.CreateQuery("from OrderFood where OrderId=:orderid and FoodId=:foodid")
				.SetInt32("orderid", orderid)
				.SetInt32("foodid", foodid)
				.List<OrderFood>();
		}

		/// <summary>
		/// 通过OrderId和FoodId得到OrderFood，增加食物份数num份
		/// </summary>
		/// <param name="orderid"></param>
		/// <param name="foodid"></param>
		/// <param name="num"></param>
		public void AddFoodNum(int orderid, int foodid, int num)
		{
			//获取订单食物OrderFood，然后修改它的份数，写入到数据库
			OrderFood orderfood = this.GetOrderFoodByOrderIdAndFoodId(orderid, foodid).First();
			orderfood.FoodNum += num;
			this.UpdateOrderFood(orderfood);
		}

		/// <summary>
		/// 通过传入OrderFood对象，修改、更新数据库信息
		/// </summary>
		/// <param name="orderfood"></param>
		public void UpdateOrderFood(OrderFood orderfood)
		{
			using (ITransaction tx = Session.BeginTransaction())
			{
				try
				{
					Session.Update(orderfood);
					Session.Flush();
					tx.Commit();
				}
				catch (HibernateException)
				{
					tx.Rollback();
					throw;
				}
			}
		}

		/// <summary>
		/// 查询订单的食物数量
		/// </summary>
		/// <param name="orderid"></param>
		/// <returns></returns>
		public int GetFoodNumByOrderId(int orderid)
		{
			//Session求和之后返回List数组，因为这里求和所以结果只有一个，取出下标为0的元素
			//List里面的类型是object/Int64类型的，要先转换成字符串，再转换成Int32
			//测试的时候没问题，打开网页的时候果断抛异常了。。。
			/*return Convert.ToInt32(Session.CreateQuery("select sum(FoodNum) from OrderFood where OrderId = :orderid")
				.SetInt32("orderid", orderid).List()[0].ToString());*/
			int sum = 0;
			IList<OrderFood> orderfoodlist = Session.CreateQuery("from OrderFood where orderid = :orderid")
				.SetInt32("orderid", orderid)
				.List<OrderFood>();
			foreach (var v in orderfoodlist)
			{
				sum += v.FoodNum;
			}
			return sum;
		}

		/// <summary>
		/// 查询订单总金额
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public double GetTotalByOrderId(int orderid)
		{
			double total = 0;
			double price = 0;
			IList<OrderFood> orderfoodlist = Session.CreateQuery("from OrderFood where OrderId = :orderid")
				.SetInt32("orderid", orderid).List<OrderFood>();
			foreach (var v in orderfoodlist)
			{
				IList<Food> foodlist = Session.CreateQuery("from Food where FoodId = :foodid")
					.SetInt32("foodid", v.FoodId).List<Food>();
				if (foodlist.Count > 0)
				{
					price = foodlist.First().FoodPrice;
					total += price * v.FoodNum;
				}
			}
			return total;
		}

		#endregion
	}
}
