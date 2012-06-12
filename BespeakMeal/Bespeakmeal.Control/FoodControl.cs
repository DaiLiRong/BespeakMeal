using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
namespace BespeakMeal.Control
{
	public class FoodControl
	{
		private FoodData _food = new FoodData();
		private OrderFoodData _orderfood = new OrderFoodData();

		/// <summary>
		/// 订单食物列表转换为管理食物列表
		/// </summary>
		/// <param name="foodlist"></param>
		/// <returns></returns>
		public IList<ManagerFoodItem> GetManagerFoodItemByFoodList(IList<Food> foodlist)
		{
			IList<ManagerFoodItem> managerfooditemlist= new List<ManagerFoodItem>();
			foreach (var v in foodlist)
			{
				ManagerFoodItem mfi = new ManagerFoodItem();
				mfi.FoodId = v.FoodId;
				mfi.FoodName = v.FoodName;
				mfi.FoodType = v.FoodType;
				mfi.FoodPrice = v.FoodPrice;
				mfi.Status = (1 == v.Status) ? "已上架" : "已下架";
				mfi.FoodContent = v.FoodContent;
				mfi.SaleNum = _orderfood.GetFoodSaleNum(v.FoodId);

				managerfooditemlist.Add(mfi);
			}
			return managerfooditemlist;
		}
	}
}
