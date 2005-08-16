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
	public partial class DeleteUser : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["User"] == null) {
				(Master as Dreadnought_Master).Message("You have to specify the full name of the user using the querystring parameter 'User'.");
				DisableAll();
				return;
			}


			User user = Dreadnought.User.GetByName(Request.QueryString["User"].ToString()); 
			if (user==null) {
				(Master as Dreadnought_Master).Message("The specified user does not exist.");
				DisableAll();
				return;
			}

			lblUser.Text = user.Name;
		}

		protected void btnDelete_Click(object sender, EventArgs e) {
			if (!btnDelete.Enabled)
				return;
			Dreadnought.User.Delete(Request.QueryString["User"].ToString());
			Response.Redirect("~/");
		}

		void DisableAll() {
			btnDelete.Enabled = false;
		}

	}
}
