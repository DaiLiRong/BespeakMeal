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
		string struserid = Convert.ToString(Session["UserId"]);
		if ("" == struserid)
			return;
		userid = Convert.ToInt32(Session["UserId"]);

		//要获取的订单信息：订单号（日期跟订单ID的组合）、下单时间、数量、总价、留言、订单状态（1下单2付款3完成交易）
		//从Order中获取的项有：orderid,userid,ordertime,address,phonenum,otherquest,status
		OrderControl oc = new OrderControl();
		IList<OrderItem> orderlist = oc.GetOrderItemListByUserId(userid);
		if (!IsPostBack)
		{
			OrderList.DataSource = orderlist;
			OrderList.DataBind();
		}
	}
	protected void LinkButton1_Click(object sender, EventArgs e)
	{

	}
}