using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dreadnought {
	public class PageInfo {

		public PageInfo(string relativePath) {
			relativePath = relativePath.Trim(new char[] { '/', '\\', ' ' });
			if (!relativePath.EndsWith(".aspx"))
				relativePath += ".aspx";
			relativePath = relativePath.Replace("\\", "/");

			this.relativePath = relativePath;
			if (relativePath.LastIndexOf("/") >= 0)
				relativeDirectory = relativePath.Substring(0, relativePath.LastIndexOf("/") + 1);
			else
				relativeDirectory = "";

			physicalPath = Base.Configuration.PhysicalApplicationPath + relativePath.Replace("/", "\\");
			if (physicalPath.LastIndexOf("\\") >= 0)
				physicalDirectory = physicalPath.Substring(0, physicalPath.LastIndexOf("\\"));
			else
				physicalDirectory = Base.Configuration.PhysicalApplicationPath;

			master = Base.Configuration.Default_Master;
			title = Base.Configuration.Default_Title;
			theme = Base.Configuration.Default_Theme;
			text = Base.Configuration.Default_Text;

			date = DateTime.Now;
		}

		#region " Properties "
		string physicalPath;
		public string PhysicalPath {
			get {
				return physicalPath;
			}
		}

		string physicalDirectory;
		public string PhysicalDirectory {
			get {
				return physicalDirectory;
			}
		}

		string relativePath;
		public string RelativePath {
			get {
				return relativePath;
			}
		}

		string relativeDirectory;
		public string RelativeDirectory {
			get {
				return relativeDirectory;
			}
		}

		string master;
		public string Master {
			get {
				return master;
			}
			set {
				master = value;
			}
		}

		string author;
		public string Author {
			get {
				return author;
			}
			set {
				author = value;
			}
		}

		string title;
		public string Title {
			get {
				return title;
			}
			set {
				title = value;
			}
		}

		string theme;
		public string Theme {
			get {
				return theme;
			}
			set {
				theme = value;
			}
		}

		DateTime date;
		public DateTime Date {
			get {
				return date;
			}
			set {
				date = value;
			}
		}

		string text;
		public string Text {
			get {
				return text;
			}
		}
		#endregion

		public void Load() {
			if (!Exists)
				throw new PageDoesNotExistException("The page '" + relativePath + "' does not exist.");

			foreach (string invalidDirectory in Base.Configuration.Invalid_Directories)
				if (relativeDirectory.ToLower().StartsWith(invalidDirectory))
					throw new InvalidDirectoryException("It is not allowed to load a page from the directory '" + relativeDirectory + "'.");


			StreamReader reader = new StreamReader(PhysicalPath);
			string input = reader.ReadToEnd().Trim();
			reader.Close();

			Regex regex;

			//gets the master
			regex = new System.Text.RegularExpressions.Regex("<%@ Page .* MasterPageFile=\"(?<master>.*?)\" ");
			if (regex.IsMatch(input))
				master = regex.Match(input).Groups["master"].Value;
			else
				master = "";

			//gets the title
			regex = new System.Text.RegularExpressions.Regex("<%@ Page .* Title=\"(?<title>.*?)\" ");
			if (regex.IsMatch(input))
				title = regex.Match(input).Groups["title"].Value;
			else
				title = "";

			//gets the theme
			regex = new System.Text.RegularExpressions.Regex("<%@ Page .* Theme=\"(?<theme>.*?)\" ");
			if (regex.IsMatch(input))
				theme = regex.Match(input).Groups["theme"].Value;
			else
				theme = "";

			//gets the author
			regex = new System.Text.RegularExpressions.Regex("author = \"(?<Author>.*?)\";");
			author = regex.Match(input).Groups["Author"].Value;

			//gets the date
			regex = new System.Text.RegularExpressions.Regex("date = new DateTime\\((?<date>\\d*?)\\);");
			date = new DateTime(long.Parse(regex.Match(input).Groups["date"].Value));

			//everything below the script block is text
			text = input.Substring(input.IndexOf("</script>") + 9);
		}

		public void Save() {
			if (!Exists) {
				foreach (string invalidDirectory in Base.Configuration.Invalid_Directories)
					if (relativeDirectory.ToLower().StartsWith(invalidDirectory))
						throw new InvalidDirectoryException("It is not allowed to save pages to the directory '" + relativeDirectory + "'.");
				DirectoryInfo directoryInfo = new DirectoryInfo(physicalDirectory);
				if (!directoryInfo.Exists)
					directoryInfo.Create();
			}

			string output = "<%@ Page Language=\"C#\" Inherits=\"Dreadnought.Page\"";
			if (master.Length > 0)
				output += " MasterPageFile=\"" + master + "\"";
			if (title.Length > 0)
				output += " Title=\"" + Title + "\"";
			if (theme.Length > 0)
				output += " Theme=\"" + Theme + "\"";
			output += " %>";

			output += Environment.NewLine + "<script type=\"text/C#\" runat=\"server\">";
			output += Environment.NewLine + "\tprotected override void OnPreInit(object sender, EventArgs e) {";
			output += Environment.NewLine + "\t\tdate = new DateTime(" + Date.Ticks.ToString() + ");";
			output += Environment.NewLine + "\t\tauthor = \"" + Author + "\";";
			output += Environment.NewLine + "\t}";
			output += Environment.NewLine + "</script>";
			output += Environment.NewLine + "";

			output += text;

			StreamWriter writer = new StreamWriter(PhysicalPath);
			writer.Write(output);
			writer.Close();
		}

		public void Delete() {
			new System.IO.FileInfo(PhysicalPath).Delete();
		}

		public string GetContentPlaceholderText(string contentPlaceholder) {
			Regex regex = new Regex("<asp\\:Content ID=\".*?\" ContentPlaceHolderID=\""+contentPlaceholder+"\" Runat=\"server\">(?<text>[\\s\\S]*?)</asp\\:Content>",RegexOptions.IgnoreCase);
			if (regex.IsMatch(text)) {
				Match match = regex.Match(text);
				return match.Groups["text"].Value;
			}
			return text;
		}

		public void SetContentPlaceholderText(string contentPlaceholder, string text) {
			if (contentPlaceholder.Length <= 0) {
				this.text = text;
				return;
			}

			Regex regex = new Regex("<asp\\:Content ID=\"Content_.*?\" ContentPlaceHolderID=\"(?<contentPlaceholder>.*?)\" Runat=\"server\">[\\s\\S]*?</asp\\:Content>",RegexOptions.IgnoreCase);
			if (regex.IsMatch(this.text)) { //the ContentPlaceholder already exists
				Match match = regex.Match(this.text);
				this.text = this.text.Remove(match.Index, match.Length);
				this.text = this.text.Insert(match.Index, "<asp:Content ID=\"Content_" + contentPlaceholder + "\" ContentPlaceHolderID=\"" + contentPlaceholder + "\" Runat=\"server\">" + Environment.NewLine + text + Environment.NewLine + "</asp:Content>");
			}
			else //this ContentPlaceholder is new
				this.text += Environment.NewLine + "<asp:Content ID=\"Content_" + contentPlaceholder + "\" ContentPlaceHolderID=\"" + contentPlaceholder + "\" Runat=\"server\">" + Environment.NewLine + text + Environment.NewLine + "</asp:Content>";
		}

		public bool Exists {
			get {
				return new FileInfo(physicalPath).Exists;
			}
		}

	}
}