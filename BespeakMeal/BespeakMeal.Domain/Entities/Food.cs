using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
namespace BespeakMeal.Domain.Entities
{
	/// <UserDomain>
	/// 编写持久化类,来映射成为数据库表tbl_food
	/// </UserDomain>
	public class Food
	{
		public virtual int FoodId { get; set; }
		public virtual string FoodName { get; set; }
		public virtual double FoodPrice { get; set; }
		public virtual string FoodType { get; set; }
		public virtual int Status { get; set; }
		public virtual string FoodContent { get; set; }

		//多对多关系：Food属于多个Orders
		//public virtual IList<Order> Orders { get; set; }
	}
}
