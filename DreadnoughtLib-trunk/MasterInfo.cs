using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dreadnought {
	public class MasterInfo {

		public MasterInfo(string relativePath) {
			relativePath = relativePath.Trim(new char[] { '/', '\\', ' ', '~' });
			if (!relativePath.EndsWith(".master"))
				relativePath += ".master";
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

			text = Base.Configuration.Default_Master_Text;
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

		string text;
		public string Text {
			get {
				return text;
			}
			set {
				text = value;
			}
		}
		#endregion

		public void Load() {
			if (!Exists)
				throw new PageDoesNotExistException("The master '" + relativePath + "' does not exist.");

			if (Base.IsAnInvalidDirectory(relativePath))
					throw new InvalidDirectoryException("It is not allowed to load a master from the directory '" + relativeDirectory + "'.");

			StreamReader reader = new StreamReader(PhysicalPath);
			string input = reader.ReadToEnd().Trim();
			reader.Close();

			//everything below the directive block is text
			text = input.Substring(input.IndexOf("%>") + 2);
		}

		public void Save() {
			if (!Exists) {
				foreach (string invalidDirectory in Base.Configuration.Invalid_Directories)
					if (relativeDirectory.ToLower().StartsWith(invalidDirectory))
						throw new InvalidDirectoryException("It is not allowed to save masters to the directory '" + relativeDirectory + "'.");
				DirectoryInfo directoryInfo = new DirectoryInfo(physicalDirectory);
				if (!directoryInfo.Exists)
					directoryInfo.Create();
			}

			string output = "<%@ Master Language=\"C#\" Inherits=\"Dreadnought.Master\" %>";

			output += "<html><head></head><body>";
			output += text;
			output += "</body></html>";

			StreamWriter writer = new StreamWriter(PhysicalPath);
			writer.Write(output);
			writer.Close();
		}

		public void Delete() {
			new System.IO.FileInfo(PhysicalPath).Delete();
		}

		public bool Exists {
			get {
				return new FileInfo(physicalPath).Exists;
			}
		}

		public string[] GetContentPlaceholders() {
			List<string> contentPlaceholders = new List<string>();
			Regex regex = new Regex("<asp\\:contentplaceholder id=\"(?<contentPlaceholder>.*?)\" runat=\"server\">[\\s\\S]*?</asp\\:contentplaceholder>", RegexOptions.IgnoreCase);
			foreach (Match match in regex.Matches(text))
				contentPlaceholders.Add(match.Groups["contentPlaceholder"].Value);
			return contentPlaceholders.ToArray();
		}



	}
}