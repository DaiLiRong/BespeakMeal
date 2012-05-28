using System;
//using System.Collections.Generic;//不能再用System提供的ISet
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
namespace BespeakMeal.Domain.Entities
{
	/// <UserDomain>
	/// 编写持久化类,来映射成为数据库表tbl_user
	/// </UserDomain>
	public class User
	{
		public virtual int UserId { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Password { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual char Gender { get; set; }
		public virtual string PhoneNum { get; set; }
		public virtual string Email { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual int SuperUser { get; set; }
		public virtual int Status { get; set; }

		//一对多关系：User有一个或者多个Orders
		//访问对象方式：通过子集合访问：User.Orders[...]
		public virtual ISet<Order> Orders { get; set; }
	}
}
