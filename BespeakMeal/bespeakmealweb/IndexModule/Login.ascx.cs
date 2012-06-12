using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NHibernate;
using NHibernate.Cfg;
using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class IndexModule_Login : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["UserName"] != null)
		{
			
			//已经登录，显示用户界面
			this.Panel1.Visible = false;
			this.Panel2.Visible = true;
			if (Convert.ToString(Session["UserType"]) == "管理员")
			{
				Manager.Visible = true;
			}
			else
				Manager.Visible = false;
			GetProductNum();
		}
		else
		{
			//未登录
			this.Panel2.Visible = false;
			this.Panel1.Visible = true;
		}
	}

	/// <summary>
	/// 用户模块中设置购物车中食物数量
	/// </summary>
	/// <param name="orderControl"></param>
	public void GetProductNum()
	{
		//设置购物车数量
		int userid = Convert.ToInt32(Session["UserId"].ToString());
		OrderControl orderControl = new OrderControl();
		IList<OrderFood> orderfoodlist = orderControl.GetProductCarFoodList(userid);
		int productnum = 0;
		foreach (var u in orderfoodlist)
		{
			productnum += u.FoodNum;
		}
		this.MyCar.Text = "我的购物车[" + productnum.ToString() + "]";
	}

	protected void UserLogin_Click(object sender, EventArgs e)
	{
		//对用户输入进行编码
		string username = Server.HtmlEncode(UserName.Text.Trim());
		string password = Server.HtmlEncode(Password.Text.Trim());
		UserData userdata = new UserData();
		IList<User> userlist = userdata.GetUserByUserName(username);
		if (userlist.Count >= 1 && password == userlist.First().Password)
		{
			string usertype = userlist.First().SuperUser == 1 ? "管理员" : "会员";
			string userid = userlist.First().UserId.ToString();
			LabelSuccessOrNot.Text = "登录成功，请稍后...";
			//写会话对象
			Session["UserName"] = username;
			Session["UserType"] = usertype;
			Session["UserId"] = userid;

			//写Cookies
			Response.Cookies["UserInfo"]["UserName"] = username;
			Response.Cookies["UserInfo"]["UserType"] = usertype;
			Response.Cookies["UserInfo"]["UserId"] = userid;
			Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(1);

			//已经登录，显示用户界面
			this.Panel1.Visible = false;
			this.Panel2.Visible = true;
			if (usertype == "管理员")
			{
				Manager.Visible = true;
			}
			GetProductNum();
		}
		else
			LabelSuccessOrNot.Text = "登录失败";
	}
	protected void LinkButton1_Click(object sender, EventArgs e)
	{

	}

	//退出登录
	protected void Logout_Click(object sender, EventArgs e)
	{
		LabelSuccessOrNot.Text = "已退出...";
		Manager.Visible = false;
		//删除会话对象
		Session.Clear();

		//删除Cookies
		Response.Cookies.Remove("UserInfo");

		//未登录
		this.Panel2.Visible = false;
		this.Panel1.Visible = true;
		Response.Write("<script language=javascript>window.location.href='index.aspx';</script>");
	}
	//跳转到首页
	protected void MainPage_Click(object sender, EventArgs e)
	{
		Response.Write("<script language=javascript>window.location.href='index.aspx';</script>");
	}
	//跳转到购物车
	//protected void MyCar_Click(object sender, EventArgs e)
	//{
	//    Response.Write("<script language=javascript>window.location.href='UserPage/ProductCarShow.aspx';</script>");
	//}
	//protected void LinkButton3_Click(object sender, EventArgs e)
	//{
	//    Response.Write("<script language=javascript>window.location.href='UserPage/UserInfo.aspx';</script>");
	//}
}