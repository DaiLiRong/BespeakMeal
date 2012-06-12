using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Control;

public partial class IndexModule_PayNow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string userid = Convert.ToString(Session["UserId"]);
		if ("" == userid)
		{
			Page.Response.Write("<script>alert('请重新登录!')</script>");
			return;
		}
		//显示应付款项
		string total = Convert.ToString(Session["OrderTotal"]);
		if (null == total && "" == total)
		{

		}
		else
			TotalLabel.Text = total;
    }

	/// <summary>
	/// 点击已完成付款的处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void FinishPayLink_Click(object sender, EventArgs e)
	{
		OrderControl oc = new OrderControl();
		string orderid = Convert.ToString(Session["OrderId"]);
		if("" != orderid && null != orderid)
		{
			int OrderId = Convert.ToInt32(orderid);
			oc.PayOrderByOrderId(OrderId);
			Session["OrderId"] = null;
			Response.Write("<script language=javascript>window.location.href='MyOrder.aspx';</script>");
		}
	}
}