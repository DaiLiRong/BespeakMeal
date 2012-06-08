using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
namespace BespeakMeal.Domain.Entities
{
	/// <summary>
	/// 编写持久化类,来映射成为数据库表tbl_order
	/// </summary>
	public class Order
	{
		public virtual int OrderId { get; set; }
		public virtual int UserId { get; set; }
		public virtual DateTime OrderTime { get; set; }
		public virtual string EatType { get; set; }
		public virtual string Address { get; set; }
		public virtual string OtherRequest { get; set; }
		public virtual int status { get; set; }

		//多对一关系：Orders属于一个User
		//访问对象方式：通过父对象成员访问：Order.User
		//public virtual User User { get; set; }

		//一对多关系：Order有多个Foods
		//public virtual IList<Food> Foods { get; set; }
	}
}
