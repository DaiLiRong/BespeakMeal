using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string usertype = Convert.ToString(Session["UserType"]);
		string username = Convert.ToString(Session["UserName"]);
		if ("" == username || "管理员" != usertype)
		{
			Page.Response.Write("<script>alert('请重新登录!')</script>");
			Response.Write("<script language=javascript>window.location.href='index.aspx';</script>");
			return;
		}
    }
}