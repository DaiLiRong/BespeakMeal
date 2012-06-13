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
	private FoodData _food = new FoodData();
	private FoodControl _foodControl = new FoodControl();
	private IList<Food> foodlist;
	private IList<ManagerFoodItem> managerfooditemlist;
	public _Default()
	{
		foodlist = _food.GetAllFood();
		managerfooditemlist = _foodControl.GetManagerFoodItemByFoodList(foodlist);
	}
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			ManagerFoodList.DataSource = managerfooditemlist;
			ManagerFoodList.DataBind();
		}
    }

	/// <summary>
	/// 点击查看按钮
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CheckLinkButton_Click(object sender, EventArgs e)
	{
		//显示食物详情
		FoodDetail.Visible = true;
		AllFood.Visible = false;

		//获取食物的索引

		LinkButton lbton = (LinkButton)sender;
		DataListItem gvr = (DataListItem)lbton.Parent;
		int foodindex = gvr.ItemIndex;

		ManagerFoodItem managerfooditem = managerfooditemlist[foodindex];
		Session["FoodId"] = Convert.ToString(managerfooditem.FoodId);

		FoodImage.ImageUrl = @"img\" + Convert.ToString(managerfooditem.FoodId) + @".jpg";
		FoodNameLabel.Text = managerfooditem.FoodName;
		TypeLabel.Text = managerfooditem.FoodType;
		PriceLabel.Text = Convert.ToString(managerfooditem.FoodPrice);
		DisCountLabel.Text = "1";
		StatusLabel.Text = managerfooditem.Status;
		ContentLabel.Text = managerfooditem.FoodContent;
		SaleNumLabel.Text = Convert.ToString(managerfooditem.SaleNum) + "件";
		StatusLinkButton.Text = (managerfooditem.Status == "已下架") ? "上菜" : "下架";
	}

	//修改食物信息
	protected void ChangeFoodName_Click(object sender, EventArgs e)
	{
		FoodNameLabel.Visible = false;
		ChangeFoodName.Visible = false;
		FoodNameTextBox.Visible = true;
		ConfirmFoodName.Visible = true;
		FoodNameTextBox.Text = FoodNameLabel.Text;
	}
	protected void ChangeType_Click(object sender, EventArgs e)
	{
		TypeLabel.Visible = false;
		ChangeType.Visible = false;
		TypeTextBox.Visible = true;
		ConfirmType.Visible = true;
		TypeTextBox.Text = TypeLabel.Text;
	}
	protected void ChangePrice_Click(object sender, EventArgs e)
	{
		PriceLabel.Visible = false;
		ChangePrice.Visible = false;
		PriceTextBox.Visible = true;
		ConfirmPrice.Visible = true;
		PriceTextBox.Text = PriceLabel.Text;
	}
	protected void ChangeDisCount_Click(object sender, EventArgs e)
	{
		DisCountLabel.Visible = false;
		ChangeDisCount.Visible = false;
		DisCountTextBox.Visible = true;
		ConfirmDisCount.Visible = true;
		DisCountTextBox.Text = DisCountLabel.Text;
	}
	protected void ConfirmFoodName_Click(object sender, EventArgs e)
	{
		FoodData _food = new FoodData();
		int foodid = Convert.ToInt32(Session["FoodId"]);
		Food tempfood = _food.GetFoodById(foodid);
		tempfood.FoodName = FoodNameTextBox.Text;
		_food.UpdateFood(tempfood);
		FoodNameLabel.Visible = true;
		ChangeFoodName.Visible = true;
		FoodNameTextBox.Visible = false;
		ConfirmFoodName.Visible = false;
		FoodNameLabel.Text = FoodNameTextBox.Text;
	}
	protected void ConfirmType_Click(object sender, EventArgs e)
	{
		FoodData _food = new FoodData();
		int foodid = Convert.ToInt32(Session["FoodId"]);
		Food tempfood = _food.GetFoodById(foodid);
		tempfood.FoodType = TypeTextBox.Text;
		_food.UpdateFood(tempfood);
		TypeLabel.Visible = true;
		ChangeType.Visible = true;
		TypeTextBox.Visible = false ;
		ConfirmType.Visible = false;
		TypeLabel.Text = TypeTextBox.Text;
	}
	protected void ConfirmPrice_Click(object sender, EventArgs e)
	{
		FoodData _food = new FoodData();
		int foodid = Convert.ToInt32(Session["FoodId"]);
		Food tempfood = _food.GetFoodById(foodid);
		PriceLabel.Visible = true;
		ChangeType.Visible = true;
		PriceTextBox.Visible = false;
		ConfirmPrice.Visible = false;
		try { tempfood.FoodPrice = Convert.ToDouble(PriceTextBox.Text); }
		catch { return; }
		_food.UpdateFood(tempfood);
		PriceLabel.Text = PriceTextBox.Text;
	}
	protected void ConfirmDisCount_Click(object sender, EventArgs e)
	{
		//FoodData _food = new FoodData();
		//int foodid = Convert.ToInt32(Session["FoodId"]);
		//Food tempfood = _food.GetFoodById(foodid);
		//tempfood. = Convert.ToDouble(PriceTextBox.Text);
		//_food.UpdateFood(tempfood);
		DisCountLabel.Visible = true;
		ChangeDisCount.Visible = true;
		DisCountTextBox.Visible = false;
		ConfirmDisCount.Visible = false;
		//PriceLabel.Text = PriceTextBox.Text;
	}
	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		//返回
		FoodDetail.Visible = false;
		AllFood.Visible = true;
		Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
	}
	protected void StatusLinkButton_Click(object sender, EventArgs e)
	{
		int foodstatus = 0;
		if ("上菜" == StatusLinkButton.Text)
		{
			foodstatus = 1;
		}
		else foodstatus = 0;

		FoodData _food = new FoodData();
		int foodid = Convert.ToInt32(Session["FoodId"]);
		Food tempfood = _food.GetFoodById(foodid);
		tempfood.Status = foodstatus;
		_food.UpdateFood(tempfood);

		if (1 == foodstatus)
		{
			StatusLabel.Text = "已上架";
			StatusLinkButton.Text = "下架";
		}
		else
		{
			StatusLabel.Text = "已下架";
			StatusLinkButton.Text = "上菜";
		}
	}

	protected void AddNewFood_Click(object sender, EventArgs e)
	{
		AllFood.Visible = false;
		FoodDetail.Visible = false;
		AddNewFoodPanel.Visible = true;
	}

	/// <summary>
	/// 将新食物写入数据库
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SubmitNewFood_Click(object sender, EventArgs e)
	{
		string foodname = TextBox1.Text;
		double foodprice = 0.0;
		try
		{
			foodprice = (Convert.ToDouble(TextBox2.Text));
		}
		catch
		{
			Label1.Text = "请输入正确的信息！";
			return;
		}
		string foodtype = TextBox3.Text;
		string foodcontent = TextBox4.Text;

		Food food = new Food
		{
			FoodName = foodname,
			FoodPrice = foodprice,
			FoodType = foodtype,
			FoodContent = foodcontent,
			Status = 1
		};
		int foodid = _food.CreateFood(food);
		Session["FoodId"] = Convert.ToString(foodid);
		FileUpLoadPanel.Visible = true;
		SubmitNewFood.Visible = false;
	}


	protected void UpLoadImg_Click(object sender, EventArgs e)
	{
		string savePath = @"C:\xampp\htdocs\bespeakmeal\img\";//定义保存路径
		if (FoodImg.HasFile)//判断FileUpload1是否选择文件
		{
			string filename = FoodImg.FileName;//定义变量获取文件名
			string imagename = Convert.ToString(Session["FoodId"]) + "." + filename.Split('.').ElementAt(1);
			savePath += imagename;
			FoodImg.SaveAs(savePath);//将选择的文件保存
			FileUpLoadPanel.Visible = false;
			AddNewFoodPanel.Visible = false;
			FoodDetail.Visible = true; 
			SubmitNewFood.Visible = true;
			Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");
		}
	}
	protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
	{
		if ("添加新菜" == Menu1.SelectedValue)
		{
			AllFood.Visible = false;
			FoodDetail.Visible = false;
			AddNewFoodPanel.Visible = true;
		}
	}
}