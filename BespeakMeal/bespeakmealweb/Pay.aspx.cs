using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		string userid = Convert.ToString(Session["UserId"]);
		if ("" == userid)
		{
			Page.Response.Write("<script>alert('请重新登录!')</script>");
			return;
		}
		Response.Write("<script language=javascript>window.location.href='PayNow.aspx';</script>");
	}
}