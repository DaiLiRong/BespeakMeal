using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BespeakMeal.Control
{
	public class ManagerFoodItem
	{
		private int foodid;
		private string foodname;
		private string foodtype;
		private double foodprice;
		private string status;
		private int salenum;
		private string foodcontent;

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
		public string FoodType
		{
			get { return foodtype; }
			set { foodtype = value; }
		}
		public double FoodPrice
		{
			get { return foodprice; }
			set { foodprice = value; }
		}
		public string Status
		{
			get { return status; }
			set { status = value; }
		}
		public int SaleNum
		{
			get { return salenum; }
			set { salenum = value; }
		}
		public string FoodContent
		{
			get { return foodcontent; }
			set { foodcontent = value; }
		}
	}
}
