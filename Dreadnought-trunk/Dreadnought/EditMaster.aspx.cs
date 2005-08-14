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
	public partial class EditMaster : System.Web.UI.Page {

		MasterInfo masterInfo;

		protected void Page_Load(object sender, EventArgs e) {
			if (Request.QueryString["Master"] == null) {
				(Master as Dreadnought_Master).Message("No master specified. Please use the querystring Master to specify the full relative path to a page.");
				DisableAll();
				return;
			}

			masterInfo = new MasterInfo(Request.QueryString["Master"]);
			try {
				masterInfo.Load();
			} catch (PageDoesNotExistException) {
				(Master as Dreadnought_Master).Message("The specified master does not exist (<a href=\"CreateMaster.aspx?Master=" + masterInfo.RelativePath + "\">Create it</a>).");
				DisableAll();
				return;
			} catch (InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You are not allowed to load a master from the directory '" + masterInfo.RelativeDirectory + "'.");
				DisableAll();
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficient user rights.");
				DisableAll();
				return;
			}

			if (!IsPostBack)
				LoadText();
		}


		void DisableAll() {
			btnExit.Enabled = false;
			btnSave.Enabled = false;
			btnSaveAndExit.Enabled = false;
		}


		void LoadText() {
			editor.Value = masterInfo.Text;
		}


		void SaveText() {
			masterInfo.Text = editor.Value.Replace("contentplaceholder", "asp:contentplaceholder");
			try { //there should be no exception, but just to make sure
				masterInfo.Save();
			} catch (Dreadnought.InvalidDirectoryException) {
				(Master as Dreadnought_Master).Message("You cannot save a master in the directory '" + masterInfo.RelativeDirectory + "'.");
				return;
			} catch {
				(Master as Dreadnought_Master).Message("An unexpected error occurred. Please make sure you have sufficent user rights.");
				return;
			}
		}

		void Redirect() {
			Response.Redirect("~/");
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
}
}
