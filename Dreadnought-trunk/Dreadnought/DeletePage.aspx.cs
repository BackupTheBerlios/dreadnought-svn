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
	public partial class DeletePage : System.Web.UI.Page {

		PageInfo pageInfo;

		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["Page"] == null) {
				(Master as Dreadnought_Master).Message("You have to specify the full relative path of a page using the querystring parameter 'Page'.");
				DisableAll();
				return;
			}

			pageInfo = new PageInfo(Request.QueryString["Page"]);
			if (!pageInfo.Exists) {
				(Master as Dreadnought_Master).Message("The specified page does not exist.");
				DisableAll();
				return;
			}

			lblPage.Text = pageInfo.RelativePath;
		}

		protected void btnDelete_Click(object sender, EventArgs e) {
			if (!btnDelete.Enabled)
				return;
			pageInfo.Delete();
			Response.Redirect("~/");
		}

		void DisableAll() {
			btnDelete.Enabled = false;
		}

	}
}
