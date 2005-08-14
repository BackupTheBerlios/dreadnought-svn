using System;

namespace Dreadnought {
	public abstract class Page : System.Web.UI.Page {

		public Page() {
			this.PreInit += new EventHandler(OnPreInit);
			this.InitComplete += new EventHandler(Page_InitComplete);
		}

		void Page_InitComplete(object sender, EventArgs e) {
			Response.Write(author + "_" + Name);
		}

		protected abstract void OnPreInit(object sender, EventArgs e);

		protected string author;
		public string Author {
			get {
				return author;
			}
		}

		protected DateTime date;
		public DateTime Date {
			get {
				return date;
			}
		}

		string name = "";
		public string Name {
			get {
				if (name.Length <= 0)
					name = this.Request.Path.Substring(Base.Configuration.RelativeApplicationPath.Length);
				return name;
			}
		}
	}
}
