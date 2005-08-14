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
	public partial class ManagePages : System.Web.UI.Page {


		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				foreach (string page in Base.Pages)
					lstPages.Items.Add(new ListItem(page, page));
		}

		protected void btnCreate_Click(object sender, EventArgs e) {
			Response.Redirect("CreatePage.aspx");
		}

		protected void btnEdit_Click(object sender, EventArgs e) {
			if (lstPages.SelectedIndex >= 0)
				Response.Redirect("EditPage.aspx?Page="+lstPages.SelectedValue);
		}

		protected void btnEditDetails_Click(object sender, EventArgs e) {
			if (lstPages.SelectedIndex >= 0)
				Response.Redirect("EditPageDetails.aspx?Page=" + lstPages.SelectedValue);
		}

		protected void btnDelete_Click(object sender, EventArgs e) {
			if (lstPages.SelectedIndex >= 0)
				Response.Redirect("DeletePage.aspx?Page=" + lstPages.SelectedValue);
		}
}
}
