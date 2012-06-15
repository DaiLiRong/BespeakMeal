using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class _Default : System.Web.UI.Page
{
	private OrderControl ordercontrol = new OrderControl();
	private OrderData _order = new OrderData();
	IList<ManagerOrderItem> orderlist;
	public _Default()
	{
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		
    }
	protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
	{
		if ("所有订单" == Menu1.SelectedValue)
		{
			orderlist = ordercontrol.GetAllOrderItem();
			ManagerAllOrderList.DataSource = orderlist;
			ManagerAllOrderList.DataBind();
		}
		else
		{
			orderlist = ordercontrol.GetOrderItemByStatus(Convert.ToInt32(Menu1.SelectedValue));
			ManagerAllOrderList.DataSource = orderlist;
			ManagerAllOrderList.DataBind();
		}
		Session["OrderType"] = Menu1.SelectedValue;
	}

	/// <summary>
	/// 返回后
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		AllOrders.Visible = true;
		OrderDetail.Visible = false;
		//Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}

	/// <summary>
	/// 标记订单已完成按钮事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void StatusLinkButton_Click(object sender, EventArgs e)
	{
		if ("所有订单" == Session["OrderType"])
		{
			orderlist = ordercontrol.GetAllOrderItem();
		}
		else
		{
			orderlist = ordercontrol.GetOrderItemByStatus(Convert.ToInt32(Session["OrderType"]));
		}
		int index = Convert.ToInt32(Session["ManagerOrderIndex"]);
		int orderid = orderlist[index].OrderId;
		Order order = _order.GetOrderById(orderid);
		order.status = 3;
		_order.UpdateOrder(order);
		StatusLinkButton.Visible = false;
		StatusLabel.Text = "正在送";
		StatusLabel.ForeColor = System.Drawing.Color.Green;
	}

	/// <summary>
	/// 点击查看后
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CheckLinkButton_Click(object sender, EventArgs e)
	{
		AllOrders.Visible = false;
		OrderDetail.Visible = true;
		LinkButton lbton = (LinkButton)sender;
		DataListItem gvr = (DataListItem)lbton.Parent;
		int orderindex = gvr.ItemIndex;
		Session["ManagerOrderIndex"] = Convert.ToInt32(orderindex);
		if ("所有订单" == Convert.ToString(Session["OrderType"]))
		{
			orderlist = ordercontrol.GetAllOrderItem();
		}
		else
		{
			orderlist = ordercontrol.GetOrderItemByStatus(Convert.ToInt32(Session["OrderType"]));
		}
		int index = Convert.ToInt32(Session["ManagerOrderIndex"]);
		//orderlist[index].
		OrderReference.Text = orderlist[index].OrderReference;
		UserName.Text = orderlist[index].UserName;
		PayTime.Text = Convert.ToString(orderlist[index].PayTime);
		StatusLabel.Text = orderlist[index].Status;
		switch (orderlist[index].Status)
		{
			case "未付款":
				StatusLabel.ForeColor = System.Drawing.Color.Red;
				StatusLinkButton.Visible = false;
				break;
			case "已付款":
				StatusLabel.ForeColor = System.Drawing.Color.Green;
				StatusLinkButton.Visible = true;
				break;
			case "正在送":
				StatusLabel.ForeColor = System.Drawing.Color.Green;
				StatusLinkButton.Visible = false;
				break;
			case "交易成功":
				StatusLabel.ForeColor = System.Drawing.Color.Green;
				StatusLinkButton.Visible = false;
				break;
			case "订单已取消":
				StatusLabel.ForeColor = System.Drawing.Color.Gray;
				StatusLinkButton.Visible = false;
				break;
		}
		AddressLabel.Text = orderlist[index].Address;
		PhoneLabel.Text = orderlist[index].PhoneNum;
		OrderFoodList.DataSource = orderlist[index].FoodList;
		OrderFoodList.DataBind();
		Total.Text = orderlist[index].Total.ToString();
	}
}