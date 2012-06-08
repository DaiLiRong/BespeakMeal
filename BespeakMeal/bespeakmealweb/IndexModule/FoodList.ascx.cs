using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
using BespeakMeal.Data;
public partial class IndexModule_FoodList : System.Web.UI.UserControl
{
	//显示所有食物foodlist
	private IList<Food> foodlist;
	private FoodData _food = new FoodData();
	public IndexModule_FoodList()
	{
		foodlist = _food.GetAllFood();
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		//将所有菜单绑定到DataList中显示出来
		if (!IsPostBack)
		{
			FoodListView.DataSource = foodlist;
			FoodListView.DataBind();
		}
	}

	//用户加入购物车的食物
	private OrderFoodData _orderfood = new OrderFoodData();
	private OrderData _order = new OrderData();

	///用户点击购买食物，处理订单（购物车）
	protected void FoodListView_OnItemCommand(object sender, DataListCommandEventArgs e)
	{
		//未登录
		if (Session["UserName"] == null)
		{
			Page.Response.Write("<script>alert('请登录!')</script>");
			return;
		}

		//从Session获取userId，从ItemIndex获取foodId，调用逻辑层的购物车

		//从DataList中选择，得到foodid
		FoodListView.SelectedIndex = e.Item.ItemIndex;
		int foodid = FoodListView.SelectedIndex;
		int userId = Convert.ToInt32(Session["UserId"].ToString());

		//调用逻辑层实现加入购物车
		OrderControl oc = new OrderControl();
		oc.ProductCarAddFood(userId, foodid);
		Response.Write("<script language=javascript>window.location.href='index.aspx';</script>");
	}
}