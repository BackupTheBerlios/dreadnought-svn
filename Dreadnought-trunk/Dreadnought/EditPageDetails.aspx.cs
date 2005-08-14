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
	public partial class EditPageDetails : System.Web.UI.Page {

		PageInfo pageInfo;

		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["Page"] == null) {
				(Master as Dreadnought_Master).Message("No page specified. Please use the querystring Page to specify the full relative path to a page.");
				DisableAll();
				return;
			}

			pageInfo = new PageInfo(Request.QueryString["Page"]);
			try {
				pageInfo.Load();
			} catch (PageDoesNotExistException) {
				(Master as Dreadnought_Master).Message("The specified page does not exist (<a href=\"CreatePage.aspx?Page=" + pageInfo.RelativePath + "\">Create it</a>).");
				DisableAll();
				return;
			} catch (InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You are not allowed to load a page from the directory '" + pageInfo.RelativeDirectory + "'.");
				DisableAll();
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficient user rights.");
				DisableAll();
				return;
			}

			if (!IsPostBack) {
				drpTheme.Items.Add(new ListItem("No theme", ""));
				drpMaster.Items.Add(new ListItem("No master", ""));

				foreach (string theme in Base.Themes)
					drpTheme.Items.Add(new ListItem("Theme '" + theme + "'", theme));

				foreach (string master in Base.Masters)
					drpMaster.Items.Add(new ListItem("Master '" + master + "'", "~/" + master));

				ListItem selectedMaster = drpMaster.Items.FindByValue(pageInfo.Master);
				if (selectedMaster != null)
					selectedMaster.Selected = true;

				ListItem selectedTheme = drpTheme.Items.FindByValue(pageInfo.Theme);
				if (selectedTheme != null)
					selectedTheme.Selected = true;

				txtTitle.Text = pageInfo.Title;
			}
		}


		void DisableAll() {
			drpTheme.Enabled = false;
			drpMaster.Enabled = false;
			txtTitle.Enabled = false;
			btnEdit.Enabled = false;
		}

		protected void btnEdit_Click(object sender, EventArgs e) {
			pageInfo.Master = drpMaster.SelectedValue;
			pageInfo.Theme = drpTheme.SelectedValue;
			pageInfo.Title = txtTitle.Text;

			try { //there should be no exception, but just to make sure
				pageInfo.Save();
			} catch (Dreadnought.InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You cannot save a page in the directory '" + pageInfo.RelativeDirectory + "'.");
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficent user rights.");
				return;
			}
		}
}
}
