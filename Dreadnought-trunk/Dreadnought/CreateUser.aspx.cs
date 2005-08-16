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
	public partial class CreateUser : System.Web.UI.Page {


		protected void btnCreate_Click(object sender, EventArgs e) {
			if (!IsValid) {
				(Master as Dreadnought_Master).Message("Please make sure the form is valid.");
				return;
			}

			try {
				Dreadnought.User.Create(txtName.Text, txtPassword.Text, (Userlevel)Enum.Parse(typeof(Userlevel), drpLevel.SelectedValue));
				txtName.Text = "";
				txtPassword.Text = "";			
			} catch (UserAlreadyExistsException) {
				(Master as Dreadnought_Master).Message("There is already a user with this name.");
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occured. Please make sure you have enough user rights.");
				return;
			}

		}

	}
}
