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
	public partial class CreateMaster : System.Web.UI.Page {


		protected void btnCreate_Click(object sender, EventArgs e) {
			if (!IsValid) {
				(Master as Dreadnought_Master).Message("Please make sure the form is valid.");
				return;
			}

			MasterInfo masterInfo = new MasterInfo(txtMaster.Text);

			if (masterInfo.Exists) {
				(Master as Dreadnought_Master).Message("This master already exists (<a href=\"EditMaster.aspx?Master=" + masterInfo.RelativePath + "\">Edit it</a>).");
				return;
			}

			try {
				masterInfo.Save();
			} catch (Dreadnought.InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You cannot create a master in the directory '" + masterInfo.RelativeDirectory + "'.");
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficent user rights.");
				return;
			}

			if (chkRedirect.Checked)
				Response.Redirect("EditMaster.aspx?Master=" + masterInfo.RelativePath);
		}


		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				if (Request.QueryString["Master"] != null)
					txtMaster.Text = Request.QueryString["Master"].ToString();
		}
	}
}
