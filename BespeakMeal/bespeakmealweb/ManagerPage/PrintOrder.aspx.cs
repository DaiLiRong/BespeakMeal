using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BespeakMeal.Control;
public partial class ManagerPage_PrintOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		IList<ManagerOrderItem> managerorderitemlist = new OrderControl().GetOrderItemByStatus(2);
		foreach (var v in managerorderitemlist)
		{
			Response.Write("*************欢迎光临一乐订餐*************<br/>");
			Response.Write("订单号：" + v.OrderReference + "<br/>");
			Response.Write("用户名：" + v.UserName + "<br/>");
			Response.Write("--------------销售--------------<br/>");
			Response.Write("<table><tr><td>商品名称</td><td>单价</td><td>数量</td><td>销售量</td></tr>");
			foreach(var u in v.FoodList)
			{
				Response.Write(
					"<tr><td>"+u.FoodName+"</td>" +
					"<td>" + Convert.ToString(u.FoodPrice) + "</td>" +
					"<td>" + u.FoodNum + "</td>" +
					"<td>" + u.MoneyCount + "</td></tr>");
			}
			Response.Write("<br/>");
			Response.Write("</table>");
			Response.Write("--------------------------------</br>");
			Response.Write("数量合计：" + Convert.ToString(v.FoodNum) + "<br/>");
			Response.Write("交易合计：" + Convert.ToString(v.Total) + "元<br/>");
			Response.Write("交易时间：" + v.PayTime.ToString() + "<br/>");
			Response.Write("收货地址：" + v.Address + "<br/>");
			Response.Write("联系电话：" + v.PhoneNum + "<br/>");
			Response.Write("*************非常感谢您的支持*************<br/>");
			Response.Write("<br/><br/><br/>");
		}

    }
}