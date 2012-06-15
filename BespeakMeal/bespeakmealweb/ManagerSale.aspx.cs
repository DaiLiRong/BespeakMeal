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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void sevenday_Click(object sender, EventArgs e)
	{
		DateTime today = DateTime.Now;//DateTime.Now;
		IList<Statistic> sale7 = new List<Statistic>();
		//Statistic s = new Statistic();
		int days = 7;
		for (int day = 0; day < days; day++)
		{
			DateTime hist = new DateTime(today.Year, today.Month, today.Day - day);
			sale7.Add(new Statistic(hist));
		}
		SaleList.DataSource = sale7;
		SaleList.DataBind();
	}
}