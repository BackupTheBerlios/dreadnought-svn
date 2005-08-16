using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Dreadnought.Pages {
	public partial class ManageUsers : System.Web.UI.Page {


		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				foreach (User user in Base.Users)
					lstUsers.Items.Add(new ListItem(user.Name, user.Name));
		}

		protected void btnCreate_Click(object sender, EventArgs e) {
			Response.Redirect("CreateUser.aspx");
		}

		protected void btnEdit_Click(object sender, EventArgs e) {
			if (lstUsers.SelectedIndex >= 0)
				Response.Redirect("EditUser.aspx?User=" + lstUsers.SelectedValue);
		}


		protected void btnDelete_Click(object sender, EventArgs e) {
			if (lstUsers.SelectedIndex >= 0)
				Response.Redirect("DeleteUser.aspx?User=" + lstUsers.SelectedValue);
		}
	}
}
