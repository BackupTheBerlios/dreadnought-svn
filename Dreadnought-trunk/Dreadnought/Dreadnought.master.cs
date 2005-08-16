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
	public partial class Dreadnought_Master : System.Web.UI.MasterPage {

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
					lblUser.Text = "You are logged on as " + System.Web.HttpContext.Current.User.Identity.Name + ". <a href='Logoff.aspx'>Logoff</a>. <a href='EditUser.aspx'>Details</a>.";
				else
					lblUser.Text = "You are not logged on. <a href='Logon.aspx?ReturnUrl=" + Page.AppRelativeVirtualPath + "'>Logon</a>.";

				//Dreadnought.Page page = Page as Dreadnought.Page;
				//hplEditPage.NavigateUrl = "EditPage.aspx?Page=" + page.Name;


			}
		}

		/// <summary>
		/// Displays a message on top of the page and hides the ContentPlaceholder.
		/// </summary>
		/// <param name="message">The message to display.</param>
		public void Message(string message) {
			Message(message, true);
		}

		/// <summary>
		/// Displays a message on top of the page.
		/// </summary>
		/// <param name="message">The message to display.</param>
		/// <param name="hideContentPlaceholder">Determines wether to hide or show the ContentPlaceholder.</param>
		public void Message(string message, bool hideContentPlaceholder) {
			lblMessage.Text = "<div class=\"Message\">" + message + "</div>";
			this.ContentPlaceholder.Visible = !hideContentPlaceholder;
		}

	}
}