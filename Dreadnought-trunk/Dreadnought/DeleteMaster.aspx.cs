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
	public partial class DeleteMaster : System.Web.UI.Page {

		MasterInfo masterInfo;

		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["Master"] == null) {
				(Master as Dreadnought_Master).Message("You have to specify the full relative path of a master using the querystring parameter 'Master'.");
				DisableAll();
				return;
			}

			masterInfo = new MasterInfo(Request.QueryString["Master"]);
			if (!masterInfo.Exists) {
				(Master as Dreadnought_Master).Message("The specified master does not exist.");
				DisableAll();
				return;
			}

			lblPage.Text = masterInfo.RelativePath;
		}

		protected void btnDelete_Click(object sender, EventArgs e) {
			if (!btnDelete.Enabled)
				return;
			masterInfo.Delete();
			Response.Redirect("~/");
		}

		void DisableAll() {
			btnDelete.Enabled = false;
		}

	}
}
