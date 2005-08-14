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
	public partial class ManageMasters : System.Web.UI.Page {


		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
				foreach (string page in Base.Masters)
					lstMasters.Items.Add(new ListItem(page, page));
		}

		protected void btnCreate_Click(object sender, EventArgs e) {
			Response.Redirect("CreateMaster.aspx");
		}

		protected void btnEdit_Click(object sender, EventArgs e) {
			if (lstMasters.SelectedIndex >= 0)
				Response.Redirect("EditMaster.aspx?Master="+lstMasters.SelectedValue);
		}


		protected void btnDelete_Click(object sender, EventArgs e) {
			if (lstMasters.SelectedIndex >= 0)
				Response.Redirect("DeleteMaster.aspx?Master=" + lstMasters.SelectedValue);
		}
}
}
