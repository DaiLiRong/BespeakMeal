using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BespeakMeal.Data;
using BespeakMeal.Domain.Entities;
using BespeakMeal.Control;
public partial class ChangeUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string imagename = Convert.ToString(Session["UserId"]);
		if ("" != imagename)
		{
			//显示用户头像
			Image1.ImageUrl = @"img\userimage\" + imagename + @".jpg";
			//显示用户信息
			UserData _userdata = new UserData();
			User user = _userdata.GetUserById(Convert.ToInt32(imagename));
			Label1.Text = user.UserName;
			Label2.Text = user.Name;
			Label3.Text = Convert.ToString(user.Gender);
			Label4.Text = user.PhoneNum;
			Label5.Text = user.Email;
			Label6.Text = user.CreateTime.ToShortDateString();
		}
    }
	protected void Button1_Click(object sender, EventArgs e)
	{
		string savePath = @"C:\xampp\htdocs\bespeakmeal\img\userimage\";//定义保存路径
		if (FileUpload1.HasFile)//判断FileUpload1是否选择文件
		{
			string filename = FileUpload1.FileName;//定义变量获取文件名
			string imagename = Session["UserId"].ToString() + "." + filename.Split('.').ElementAt(1);
			savePath += imagename;
			FileUpload1.SaveAs(savePath);//将选择的文件保存
			Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
		}
		Panel2.Visible = true;
		LinkButton2.Visible = false;
	}
	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		Panel1.Visible = true;
		LinkButton1.Visible = false;
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		string password = TextBox1.Text;
		int userid = Convert.ToInt32(Session["UserId"]);
		//修改密码
		if (password != "" && password == TextBox2.Text)
		{
			UserControl1 uc = new UserControl1();
			uc.ChangePassword(userid, password);

			Panel1.Visible = false;
			LinkButton1.Visible = true;
			Label7.Text = "";
		}
		else
		{
			Label7.Text = "两次密码不相同！";
		}
	}


	protected void LinkButtonName_Click(object sender, EventArgs e)
	{
		TextBoxName.Visible = true;
		ButtonName.Visible = true;
		LinkButtonName.Visible = false;
	}
	protected void LinkButtonGender_Click(object sender, EventArgs e)
	{
		RadioButtonMale.Visible = true;
		RadioButtonFemale.Visible = true;
		ButtonGender.Visible = true;
		LinkButtonGender.Visible = false;
	}
	protected void LinkButtonPhoneNum_Click(object sender, EventArgs e)
	{
		TextBoxPhoneNum.Visible = true;
		ButtonPhoneNum.Visible = true;
		LinkButtonPhoneNum.Visible = false;
	}
	protected void LinkButtonEmail_Click(object sender, EventArgs e)
	{
		TextBoxEmail.Visible = true;
		ButtonEmail.Visible = true;
		LinkButtonEmail.Visible = false;
	}


	protected void ButtonName_Click(object sender, EventArgs e)
	{
		//修改姓名
		if (TextBoxName.Text != "")
		{
			UserData _user = new UserData();
			int userid = Convert.ToInt32(Session["UserId"]);
			User tempuser = _user.GetUserById(userid);
			tempuser.Name = TextBoxName.Text;
			_user.UpdateUser(tempuser);
		}
		TextBoxName.Visible = false;
		ButtonName.Visible = false;
		LinkButtonName.Visible = true;
		//刷新本页
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
		
	}
	protected void ButtonGender_Click(object sender, EventArgs e)
	{
		//修改性别
		UserData _user = new UserData();
		int userid = Convert.ToInt32(Session["UserId"]);
		User tempuser = _user.GetUserById(userid);
		char Gender = RadioButtonMale.Checked ? '男' : '女';
		tempuser.Gender = Gender;
		_user.UpdateUser(tempuser);

		RadioButtonMale.Visible = true; 
		RadioButtonFemale.Visible = true;
		ButtonGender.Visible = true;
		LinkButtonGender.Visible = false;
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}
	protected void ButtonPhoneNum_Click(object sender, EventArgs e)
	{
		if ("" != TextBoxPhoneNum.Text)
		{
			//修改电话号码
			UserData _user = new UserData();
			int userid = Convert.ToInt32(Session["UserId"]);
			User tempuser = _user.GetUserById(userid);
			tempuser.PhoneNum = TextBoxPhoneNum.Text;
			_user.UpdateUser(tempuser);
		}
		TextBoxPhoneNum.Visible = true;
		ButtonPhoneNum.Visible = true;
		LinkButtonPhoneNum.Visible = false;
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
		
	}
	protected void ButtonEmail_Click(object sender, EventArgs e)
	{
		if ("" != TextBoxEmail.Text)
		{
			//修改Email
			UserData _user = new UserData();
			int userid = Convert.ToInt32(Session["UserId"]);
			User tempuser = _user.GetUserById(userid);
			tempuser.Email = TextBoxEmail.Text;
			_user.UpdateUser(tempuser);
		}
		TextBoxEmail.Visible = true;
		ButtonEmail.Visible = true;
		LinkButtonEmail.Visible = false;
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}

	//让上传控件可用
	protected void LinkButton2_Click(object sender, EventArgs e)
	{
		Panel2.Visible = true;
		LinkButton2.Visible = false;
	}
}