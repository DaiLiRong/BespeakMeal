using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class ProductCarShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Panel1.Visible = false;
		Panel2.Visible = true;
		int userid = Convert.ToInt32(Session["UserId"]);
		OrderControl oc = new OrderControl();
		IList<OrderFood> foodlist = oc.GetProductCarFoodList(userid);
		if (0 == foodlist.Count)
		{
			Panel1.Visible = true;
			Panel2.Visible = false;
			return;
		}
    }
	//购买，跳转到提交订单
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{

	}
}