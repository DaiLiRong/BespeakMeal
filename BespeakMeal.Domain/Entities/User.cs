using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BespeakMeal.Domain.Entities
{
	/// <summary>
	/// 编写持久化类,来映射成为数据库表
	/// </summary>
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
		public virtual int CreateTime { get; set; }
		public virtual int SuperUser { get; set; }
		public virtual int Status { get; set; }
	}
}
