using System;
using System.Collections.Generic;
using System.IO;

namespace Dreadnought {
	public static class Base {


		static Configuration configuration;
		public static Configuration Configuration {
			get {
				if (configuration == null)
					configuration = new Configuration(System.Web.HttpContext.Current.Request.PhysicalApplicationPath);
				return configuration;
			}
		}

		static List<User> users;
		public static List<User> Users {
			get {
				if (users == null)
					users = User.Load();
				return users;
			}
		}

		public static string[] Themes {
			get {
				List<string> themes = new List<string>();
				foreach (DirectoryInfo directory in new DirectoryInfo(Configuration.PhysicalApplicationPath + "\\App_Themes\\").GetDirectories())
					themes.Add(directory.Name);
				return themes.ToArray();
			}
		}

		public static string[] Pages {
			get {
				List<string> pages = new List<string>();
				GetFiles(new DirectoryInfo(Configuration.PhysicalApplicationPath), pages, "aspx");
				return pages.ToArray();
			}
		}

		public static string[] Masters {
			get {
				List<string> masters = new List<string>();
				GetFiles(new DirectoryInfo(Configuration.PhysicalApplicationPath), masters, "master");
				return masters.ToArray();
			}
		}

		static void GetFiles(DirectoryInfo directory, List<string> files, string extension) {
			int relativeOffset = Configuration.PhysicalApplicationPath.Length;
			string relativePath = directory.FullName.Replace("\\", "/") + "/";
			relativePath = relativePath.Substring(relativeOffset);

			if (!IsAnInvalidDirectory(relativePath)) {
				foreach (FileInfo file in directory.GetFiles("*." + extension))
					files.Add(file.FullName.Replace("\\","/").Substring(relativeOffset));

				foreach (DirectoryInfo subDirectory in directory.GetDirectories())
					GetFiles(subDirectory, files, extension);
			}
		}

		public static bool IsAnInvalidDirectory(string relativeDirectory) {
			foreach (string invalidDirectory in Base.Configuration.Invalid_Directories)
				if (relativeDirectory.ToLower().StartsWith(invalidDirectory))
					return true;
			return false;
		}

		public static string Hash(string stringToHash) {
			return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringToHash, "md5");
		}
	}
}
