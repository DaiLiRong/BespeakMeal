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
	private OrderControl ordercontrol = new OrderControl();
	private OrderData _order = new OrderData();
	IList<ManagerOrderItem> orderlist;
	public _Default()
	{
	}

    protected void Page_Load(object sender, EventArgs e)
    {
    }
	protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
	{

		if ("所有订单" == Menu1.SelectedValue)
		{
			orderlist = ordercontrol.GetAllOrderItem();
			ManagerAllOrderList.DataSource = orderlist;
			ManagerAllOrderList.DataBind();
		}
		else
		{
			orderlist = ordercontrol.GetOrderItemByStatus(Convert.ToInt32(Menu1.SelectedValue));
			ManagerAllOrderList.DataSource = orderlist;
			ManagerAllOrderList.DataBind();
		}
	}
}