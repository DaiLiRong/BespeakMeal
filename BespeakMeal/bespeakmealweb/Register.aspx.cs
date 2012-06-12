using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using System.Text.RegularExpressions;

public partial class Register : System.Web.UI.Page
{
	private UserData new_user = new UserData();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	//按下注册按钮进行注册
	protected void Button1_Click(object sender, EventArgs e)
	{
		string username = UserName.Text;
		string password = Password.Text;
		if(!UserExistCheck() && RightPassword())
		{
			if ("" == password)
			{
				WrongMessage.Text = "密码不能为空！";
				return;
			}
			var tempUser = new User
			{
				UserName = username,
				Password = password,
				CreateTime = DateTime.Now,
				SuperUser = 0,
				Status = 0
			};

			//操作数据库，根据返回的userid值判断是否注册成功
			int userid = new_user.CreateUser(tempUser);
			if ( userid != -1)
			{
				this.Response.Write("<script language=\"javascript\"> alert('注册成功'); </script>"); 
				//写会话对象
				Session["UserName"] = username;
				Session["UserType"] = "会员";
				Session["UserId"] = userid.ToString();

				//写Cookies
				Response.Cookies["UserInfo"]["UserName"] = username;
				Response.Cookies["UserInfo"]["UserType"] = "会员";
				Response.Cookies["UserInfo"]["UserId"] = userid.ToString();
				Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(1);

				//跳转到主页
				Response.Redirect("index.aspx");
			}
			else
			{
				Response.Write("<script>alert('注册失败，请重新注册!')</script>");
			}
		}
	}

	//判断用户是否已经存在
	protected void UserName_TextChanged(object sender, EventArgs e)
	{
		if (!UserExistCheck())
		{
			Password.Focus();
		}
		else
			UserName.Focus();
	}
	private bool UserExistCheck()
	{
		string username = UserName.Text;
		if ("" == username)
		{
			WrongMessage.Text = "用户名不能为空！";
			return true;
		}
		else if (new_user.UserExist(username))
		{
			WrongMessage.Text = "用户名已存在！";
			return true;
		}
		else
		{
			WrongMessage.Text = "";
			return false;
		}
	}

	//判断两次输入的密码是否一致
	protected void ConfirmPassword_TextChanged(object sender, EventArgs e)
	{
		if(!RightPassword())
			ConfirmPassword.Focus();
	}
	private bool RightPassword()
	{
		string password = Password.Text;
		string confirmPassword = ConfirmPassword.Text;
		if (password != confirmPassword)
		{
			WrongMessage.Text = "输入密码不一致！";
			return false;
		}
		else
		{
			WrongMessage.Text = "";
			return true;
		}
	}
}