using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BespeakMeal.Control
{
	public class OrderItem
	{
		//要获取的订单信息：订单编号（日期跟订单ID的组合）、下单时间、数量、总价、留言、订单状态（1下单2付款3完成交易）
		//从Order中获取的项有：orderid,userid,ordertime,address,phonenum,otherquest,status
		private string orderreference;
		public string OrderReference
		{
			get { return orderreference; }
			set { orderreference = value; }
		}

		private DateTime ordertime;
		public DateTime OrderTime
		{
			get { return ordertime; }
			set { ordertime = value; }
		}

		private int foodnum;
		public int FoodNum
		{
			get { return foodnum; }
			set { foodnum = value; }
		}

		private double total;
		public double Total
		{
			get { return total; }
			set { total = value; }
		}

		private string otherreq;
		public string OtherReq
		{
			get { return otherreq; }
			set { otherreq = value; }
		}

		private string status;
		public string Status
		{
			get { return status; }
			set { status = value; }
		}
	}
}
