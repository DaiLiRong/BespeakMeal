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
	private UserData _user = new UserData();
	private IList<User> userlist;

	public _Default()
	{
		userlist = _user.GetAllUser();
	}
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			UserList.DataSource = userlist;
			UserList.DataBind();
		}
    }
	protected void UpSuper_Click(object sender, EventArgs e)
	{
		LinkButton lbton = (LinkButton)sender;
		DataListItem gvr = (DataListItem)lbton.Parent;
		int userindex = gvr.ItemIndex;
		User user = _user.GetUserById(userlist[userindex].UserId);
		user.SuperUser = 1;
		_user.UpdateUser(user);
	}
}