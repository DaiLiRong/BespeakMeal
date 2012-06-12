using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class SubmitOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	//确认并提交订单
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		string userid = Convert.ToString(Session["UserId"]);
		if ("" == userid)
		{
			Page.Response.Write("<script>alert('请重新登录!')</script>");
			return;
		}
		string address = AddressBox.Text;
		string phonenum = PhoneNumBox.Text;
		string otherreq = OtherReqBox.Text;

		if ("" != address && "" != phonenum)
		{

			OrderControl ordercontrol = new OrderControl();
			int orderid = ordercontrol.SubmitOrder(Convert.ToInt32(userid),address, phonenum, otherreq);
			//orderid保存到Session中，以便付款时取出
			Session["OrderId"] = Convert.ToString(orderid);
			Response.Write("<script language=javascript>window.location.href='Pay.aspx';</script>");
		}
		else
		{
			Page.Response.Write("<script>alert('请正确填写信息!')</script>");
		}
	}
}