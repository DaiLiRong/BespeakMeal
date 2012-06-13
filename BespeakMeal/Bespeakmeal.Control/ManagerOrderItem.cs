using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Data;
namespace BespeakMeal.Control
{
	public class ManagerOrderItem : OrderItem
	{
		private int userid;
		private string username;
		//private int ordeid;
		//private DateTime ordertime;
		private DateTime paytime;
		private string address;
		private string phonenum;
		//private string otherreq;
		private IList<FoodItem> orderfoodlist;
		//private int status;


		//public int Status
		//{
		//    get { return status; }
		//    set { status = value; }
		//}
		public IList<FoodItem> FoodList
		{
			get { return orderfoodlist; }
			set { orderfoodlist = value; }
		}
		//public string OtherReq
		//{
		//    get { return otherreq; }
		//    set { otherreq = value; }
		//}
		public string PhoneNum
		{
			get { return phonenum; }
			set { phonenum = value; }
		}
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
		public DateTime PayTime
		{
			get { return paytime; }
			set { paytime = value; }
		}
		//public DateTime OrderTime
		//{
		//    get { return ordertime; }
		//    set { ordertime = value; }
		//}
		//public int OrderId
		//{
		//    get { return ordeid; }
		//    set { ordeid = value; }
		//}
		public string UserName
		{
			get { return username; }
			set { username = value; }
		}
		public int UserId
		{
			get { return userid; }
			set { userid = value; }
		}
	}
}
