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
	public partial class EditPage : System.Web.UI.Page {

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
				LoadContentPlaceholders();
				LoadText();
			}
		}


		void DisableAll() {
			drpLoad.Enabled = false;
			btnExit.Enabled = false;
			btnSave.Enabled = false;
			btnSaveAndExit.Enabled = false;
		}


		void LoadText() {
			editor.Value = pageInfo.GetContentPlaceholderText(drpLoad.SelectedValue);
		}


		void LoadContentPlaceholders() {
			drpLoad.Items.Clear();

			if (pageInfo.Master.Length > 0) {
				MasterInfo masterInfo = new MasterInfo(pageInfo.Master);
				foreach (string contentPlaceholder in masterInfo.GetContentPlaceholders()) {
					drpLoad.Items.Add(new ListItem("ContentPlaceholder '" + contentPlaceholder + "'", contentPlaceholder));
				}
			}
			else {
				drpLoad.Items.Add(new ListItem("Entire page", ""));
			}
		}


		void SaveText() {
			pageInfo.SetContentPlaceholderText(drpLoad.SelectedValue, editor.Value);
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

		void Redirect() {
			Response.Redirect("~/" + pageInfo.RelativePath);
		}

		protected void btnExit_Click(object sender, EventArgs e) {
			Redirect();
		}

		protected void btnSave_Click(object sender, EventArgs e) {
			SaveText();
		}

		protected void btnSaveAndExit_Click(object sender, EventArgs e) {
			SaveText();
			Redirect();
		}

		protected void drpLoad_SelectedIndexChanged(object sender, EventArgs e) {
			LoadText();
		}
}
}
