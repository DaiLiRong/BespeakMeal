using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
namespace BespeakMeal.Domain.Entities
{
	public class OrderFood
	{
		public virtual int OrderFoodId { get; set; }
		public virtual int OrderId { get; set; }
		public virtual int FoodId { get; set; }
		public virtual int FoodNum { get; set; }
	}
}
