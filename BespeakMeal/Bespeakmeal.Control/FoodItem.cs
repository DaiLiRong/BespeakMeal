using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BespeakMeal.Control
{
	public class FoodItem
	{
		public FoodItem()
		{
		}
		//获取购物车信息：食物图片、食物名字、单价、数量、总价
		//从OrderFood中获取的项有：订单Id（购物车）、食物Id、数量
		private int foodid;
		private string foodname;
		private double foodprice;
		private int foodnum;
		private double moneycount;
		private int orderid;
		private int status;

		public int FoodId
		{
			get { return foodid; }
			set { foodid = value; }
		}
		public string FoodName
		{
			get { return foodname; }
			set { foodname = value; }
		}
		public double FoodPrice
		{
			get { return foodprice; }
			set { foodprice = value; }
		}
		public int FoodNum
		{
			get { return foodnum; }
			set { foodnum = value; }
		}
		public double MoneyCount
		{
			get { return moneycount; }
			set { moneycount = value; }
		}
		public int OrderId
		{
			get { return orderid; }
			set { orderid = value; }
		}
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	}
}
