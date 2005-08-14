using System;
using System.Xml;

namespace Dreadnought {
	public class Configuration {

		public Configuration(string physicalApplicationPath) {
			this.physicalApplicationPath = physicalApplicationPath;
			relativeApplicationPath = System.Web.HttpContext.Current.Request.ApplicationPath + "/";

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(physicalApplicationPath + "\\App_Data\\Configuration.xml");

			XmlElement elem = xmlDoc["Dreadnought"]["DefaultSettings"];
			default_Title = elem.Attributes["Title"].Value;
			default_Master = elem.Attributes["Master"].Value;
			default_Theme = elem.Attributes["Theme"].Value;
			default_Text = elem["Text"].InnerText.Trim();
			default_Master_Text = elem["Master_Text"].InnerText.Trim();

			invalid_Directories = xmlDoc["Dreadnought"]["Directories"].Attributes["Invalid"].Value.ToLower().Split('|');
		}


		string physicalApplicationPath;
		public string PhysicalApplicationPath {
			get {
				return physicalApplicationPath;
			}
		}

		string relativeApplicationPath;
		public string RelativeApplicationPath {
			get {
				return relativeApplicationPath;
			}
		}

		string default_Title;
		public string Default_Title {
			get {
				return default_Title;
			}
		}

		string default_Master;
		public string Default_Master {
			get {
				return default_Master;
			}
		}

		string default_Text;
		public string Default_Text {
			get {
				return default_Text;
			}
		}

		string default_Theme;
		public string Default_Theme {
			get {
				return default_Theme;
			}
		}

		string default_Master_Text;
		public string Default_Master_Text {
			get {
				return default_Master_Text;
			}
		}

		string[] invalid_Directories;
		public string[] Invalid_Directories {
			get {
				return invalid_Directories;
			}
		}

	}
}
