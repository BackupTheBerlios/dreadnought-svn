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
	public partial class CreatePage : System.Web.UI.Page {


		protected void btnCreate_Click(object sender, EventArgs e) {
			if (!IsValid) {
				(Master as Dreadnought_Master).Message("Please make sure the form is valid.");
				return;
			}

			PageInfo pageInfo = new PageInfo(txtPage.Text);

			if (pageInfo.Exists) {
				(Master as Dreadnought_Master).Message("This page already exists (<a href=\"EditPage.aspx?Page=" + pageInfo.RelativePath + "\">Edit it</a>).");
				return;
			}

			try {
				pageInfo.Save();
			} catch (Dreadnought.InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You cannot create a page in the directory '" + pageInfo.RelativeDirectory + "'.");
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficent user rights.");
				return;
			}

			if (chkRedirect.Checked)
				Response.Redirect("EditPage.aspx?Page=" + pageInfo.RelativePath);
		}


		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				if (Request.QueryString["Page"] != null)
					txtPage.Text = Request.QueryString["Page"].ToString();
		}
	}
}
