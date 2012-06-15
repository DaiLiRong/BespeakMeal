using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
namespace BespeakMeal.Control
{
	/// <summary>
	/// 当天的日期和统计值
	/// </summary>
	public class Statistic
	{
		public Statistic(DateTime datetime)
		{
			this.OrderTime = datetime;
			this.Date = datetime.Year.ToString() + "-" + datetime.Month.ToString() + "-" + datetime.Day.ToString();
			this.Hour = datetime.Hour.ToString();
			this.Minute = datetime.Minute.ToString();
			//当天的销售额
			this.Total = new OrderData().GetTodayTotal(datetime);
		}

		private DateTime ordertime;
		public DateTime OrderTime
		{
			get { return ordertime; }
			set { ordertime = value; }
		}
		private string date;
		public string Date
		{
			get { return date; }
			set { date = value; }
		}
		private string hour;
		public string Hour
		{
			get { return hour; }
			set { hour = value; }
		}
		private string minute;
		public string Minute
		{
			get { return minute; }
			set { minute = value; }
		}
		private double total;
		public double Total
		{
			get { return total; }
			set { total = value; }
		}
	}
}
