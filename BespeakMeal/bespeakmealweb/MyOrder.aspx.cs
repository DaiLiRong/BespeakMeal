using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class MyOrder : System.Web.UI.Page
{
	private int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
		//OrderListPanel.Visible = true;
		//OrderDetailPanel.Visible = false;

		string struserid = Convert.ToString(Session["UserId"]);
		if ("" == struserid)
			return;
		userid = Convert.ToInt32(Session["UserId"]);

		//要获取的订单信息：订单号（日期跟订单ID的组合）、下单时间、数量、总价、留言、订单状态（1下单2付款3完成交易）
		//从Order中获取的项有：orderid,userid,ordertime,address,phonenum,otherquest,status
		OrderControl oc = new OrderControl();
		IList<OrderItem> orderlisttemp = oc.GetOrderItemListByUserId(userid);
		//按时间排序
		var orderlist = orderlisttemp.OrderByDescending(st => st.OrderTime);
		if (!IsPostBack)
		{
			OrderList.DataSource = orderlist;
			OrderList.DataBind();

		}
	}

	/// <summary>
	/// 按了查看后显示OrderDetailPanel，隐藏OrderListPanel
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		//获取订单的索引
		LinkButton lbton = (LinkButton)sender;
		DataListItem gvr = (DataListItem)lbton.Parent;
		int foodindex = gvr.ItemIndex;

		//获取这个页面上的所有OrderItem，通过foodindex索引得到orderid
		userid = Convert.ToInt32(Session["UserId"]);
		OrderControl oc = new OrderControl();
		IList<OrderItem> orderlisttemp = oc.GetOrderItemListByUserId(userid);
		//按时间排序
		var orderlist1 = orderlisttemp.OrderByDescending(st => st.OrderTime);
		IList<OrderItem> orderlist = new List<OrderItem>();
		foreach (var v in orderlist1)
		{
			orderlist.Add(v);
		}
		//将订单信息保存在Session中
		Session["OrderId"] = orderlist[foodindex].OrderId;
		//Session["OrderReference"] = orderlist[foodindex].OrderReference;
		//Session["OrderTime"] = orderlist[foodindex].OrderTime;
		//Session["OrderStatus"] = orderlist[foodindex].Status;
		Session["OrderTotal"] = orderlist[foodindex].Total;
		//Session["OrderRequest"] = orderlist[foodindex].OtherReq;

		//显示OrderDetailPanel，隐藏OrderListPanel
		OrderDetailPanel.Visible = true;
		OrderListPanel.Visible = false;

		//在OrderDetailPanel中显示该订单信息
		OrderReferenceLabel.Text = orderlist[foodindex].OrderReference;
		OrderTimeLabel.Text = orderlist[foodindex].OrderTime.ToLongDateString() +
			orderlist[foodindex].OrderTime.ToLongTimeString();
		UserNameLabel.Text = Convert.ToString(Session["UserName"]);
		StatusLabel.Text = orderlist[foodindex].Status;
		Total.Text = orderlist[foodindex].Total.ToString();

		//根据订单状态判断显示内容
		switch (orderlist[foodindex].Status)
		{
			case "未付款":
				StatusLabel.ForeColor = System.Drawing.Color.Red;
				PayNowLink.Visible = true;
				CancelLink.Visible = true;
				ConfirmLink.Visible = false;
				break;
			case "已付款":
				StatusLabel.ForeColor = System.Drawing.Color.Green;
				PayNowLink.Visible = false;
				CancelLink.Visible = false;
				ConfirmLink.Visible = true;
				break;
			case "交易成功":
				StatusLabel.ForeColor = System.Drawing.Color.Green;
				PayNowLink.Visible = false;
				CancelLink.Visible = false;
				ConfirmLink.Visible = false;
				break;
			case "订单已取消":
				StatusLabel.ForeColor = System.Drawing.Color.Gray;
				PayNowLink.Visible = false;
				CancelLink.Visible = false;
				ConfirmLink.Visible = false;
				break;
		}

		//绑定订单食物的菜单到DataList中显示
		//获取购物车信息：食物图片、食物名字、单价、数量、总价
		//从OrderFood中获取的项有：订单Id（购物车）、食物Id、数量
		OrderFoodData _orderFood = new OrderFoodData();
		IList<OrderFood> foodlist = _orderFood.GetOrderFoodListByOrderId(orderlist[foodindex].OrderId);
		if (0 == foodlist.Count)//购物车没有食物，将不显示
		{
			FoodList.Visible = false;
			return;
		}
		else
		{
			FoodList.Visible = true;
		}
		IList<FoodItem> fooditemlist = oc.GetFoodItemByOrderFoodList(foodlist);

		//Total.Text = totalmomey.ToString();
		//将所有菜单绑定到DataList中显示出来
		FoodList.DataSource = fooditemlist;
		FoodList.DataBind();
	}

	/// <summary>
	/// 按了返回后，显示“我的订单”
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void LinkButton2_Click(object sender, EventArgs e)
	{
		Session["OrderId"] = null;
		Session["OrderTotal"] = null;
		//隐藏OrderDetailPanel，显示OrderListPanel
		OrderDetailPanel.Visible = false;
		OrderListPanel.Visible = true;
	}

	/// <summary>
	/// 取消订单
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CancelLink_Click(object sender, EventArgs e)
	{
		//提示是否取消订单！！
		OrderControl oc = new OrderControl();
		oc.CancelOrderByOrderId(Convert.ToInt32(Session["OrderId"]));
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}

	/// <summary>
	/// 确认订单
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ConfirmLink_Click(object sender, EventArgs e)
	{
		//提示是否确认收货！！
		OrderControl oc = new OrderControl();
		oc.ConfirmOrderByOrderId(Convert.ToInt32(Session["OrderId"]));
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}

	/// <summary>
	/// 去网上银行付款
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void PayNowLink_Click(object sender, EventArgs e)
	{
		
	}
}