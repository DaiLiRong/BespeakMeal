using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class IndexModule_ProductCar : System.Web.UI.UserControl
{
	private IList<OrderFood> foodlist;
	private IList<FoodItem> fooditemlist;
	private int userid;
	public IndexModule_ProductCar()
	{

	}
    protected void Page_Load(object sender, EventArgs e)
    {
		Panel1.Visible = true;
		userid = Convert.ToInt32(Session["UserId"]);
		//获取购物车信息：食物图片、食物名字、单价、数量、总价
		//从OrderFood中获取的项有：订单Id（购物车）、食物Id、数量
		OrderControl oc = new OrderControl();
		foodlist = oc.GetProductCarFoodList(userid);
		if (0 == foodlist.Count)//购物车没有食物，将不显示
		{
			Panel1.Visible = false;
			return;
		}
		fooditemlist = oc.GetFoodItemByOrderFoodList(foodlist);

		double totalmomey = GetTotalMomey(fooditemlist);
		Total.Text = totalmomey.ToString();
		Session["OrderTotal"] = Convert.ToString(totalmomey);
		//将所有菜单绑定到DataList中显示出来
		if (!IsPostBack)
		{
			ProductCar.DataSource = fooditemlist;
			ProductCar.DataBind();
			//ProductCar.
		}
    }
	private double GetTotalMomey(IList<FoodItem> fooditemlist)
	{
		double total = 0;
		foreach (var v in fooditemlist)
		{
			total += v.MoneyCount;
		}
		return total;
	}
	/// <summary>
	/// 修改购物车食物数量
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ProductCar_SelectedIndexChanged(object sender, EventArgs e)
	{
		//未登录
		if (Session["UserName"] == null)
		{
			Page.Response.Write("<script>alert('请重新登录!')</script>");
			return;
		}

		//从Session获取userId，从ItemIndex获取foodId，调用逻辑层的购物车

		//从DataList中选择，得到foodid
		int foodid = ProductCar.SelectedIndex;
		int userId = Convert.ToInt32(Session["UserId"].ToString());

		//调用逻辑层实现加入购物车
		OrderControl oc = new OrderControl();
		/*oc.ProductCarAddFood(userId, foodid);
		Response.Write("<script language=javascript>window.location.href='index.aspx';</script>");*/
	}
	/// <summary>
	/// 修改食物数量
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox chk = (CheckBox)sender;
		DataListItem gvr = (DataListItem)chk.Parent;
		int a = gvr.ItemIndex;
	}

	/// <summary>
	/// 删除一条食物
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		//获取要删除的食物的索引
		LinkButton lbton = (LinkButton)sender;
		DataListItem gvr = (DataListItem)lbton.Parent;
		int foodindex = gvr.ItemIndex;

		OrderFoodControl ofc = new OrderFoodControl();
		OrderControl oc = new OrderControl();
		foodlist = oc.GetProductCarFoodList(userid);
		fooditemlist = oc.GetFoodItemByOrderFoodList(foodlist);

		int foodid = fooditemlist.ElementAt(foodindex).FoodId;
		int orderid = fooditemlist.ElementAt(foodindex).OrderId;
		Session["OrderId"] = orderid;

		//删除订单食物，如果订单里面没有食物了，就删除这个订单
		ofc.DeleteOrderFood(orderid, foodid);
		if(1 == foodlist.Count)
		{
			OrderData _order = new OrderData();
			_order.DeleteOrder(_order.GetOrderById(orderid));
		}
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}
	protected void FoodNum_TextChanged(object sender, EventArgs e)
	{
		//获取修改了的TextBox的FoodItem项的索引
		TextBox tb = (TextBox)sender;
		if (tb.Text == "0")
		{
			Page.Response.Write("<script>alert('食物数量不能为0！您可以选择删除该食物。')</script>");
			Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
			return;
		}
		DataListItem gvr = (DataListItem)tb.Parent;
		int foodindex = gvr.ItemIndex;

		//调用逻辑层修改食物数量
		int userid = Convert.ToInt32(Session["UserId"]);
		OrderFoodControl ofc = new OrderFoodControl();
		OrderControl oc = new OrderControl();
		foodlist = oc.GetProductCarFoodList(userid);
		fooditemlist = oc.GetFoodItemByOrderFoodList(foodlist);
		int foodid = fooditemlist.ElementAt(foodindex).FoodId;
		int foodnum = Convert.ToInt32(tb.Text.ToString());
		ofc.ModifyFoodNum(userid, foodid, foodnum);
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}
}