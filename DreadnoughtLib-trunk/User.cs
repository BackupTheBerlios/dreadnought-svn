using System;
using System.Collections.Generic;
using System.Xml;

namespace Dreadnought {
	public class User {

		private User() {}

		string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		string password;
		public string Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}

		Userlevel level;
		public Userlevel Level {
			get {
				return level;
			}
			set {
				level = value;
			}
		}

		public static List<User> Load() {
			List<User> users = new List<User>();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Base.Configuration.PhysicalApplicationPath + "\\App_Data\\Users.xml");

			foreach (XmlElement xmlElement in xmlDoc["Dreadnought"].GetElementsByTagName("User")) {
				User user = new User();
				user.name = xmlElement.Attributes["Name"].Value;
				user.password = xmlElement.Attributes["Password"].Value;
				user.level = (Userlevel)Enum.Parse(typeof(Userlevel), xmlElement.Attributes["Level"].Value);
				users.Add(user);
			}

			return users;
		}

		public static void Save(List<User> users) {
			XmlDocument xmlDoc = new XmlDocument();

			xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", ""));
			xmlDoc.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "Dreadnought", ""));

			foreach (User user in users) {
				XmlElement xmlElement = xmlDoc.CreateNode(XmlNodeType.Element, "User", "") as XmlElement;
				xmlElement.Attributes.Append((XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Name", ""));
				xmlElement.Attributes.Append((XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Password", ""));
				xmlElement.Attributes.Append((XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Level", ""));

				xmlElement.Attributes["Name"].Value = user.name;
				xmlElement.Attributes["Password"].Value = user.password;
				xmlElement.Attributes["Level"].Value = user.level.ToString();
				xmlDoc["Dreadnought"].AppendChild(xmlElement);
			}

			xmlDoc.Save(Base.Configuration.PhysicalApplicationPath + "\\App_Data\\Users.xml");
		}

		public static void Create(string name, string password, Userlevel level) {
			User user = GetByName(name);
			if (user != null)
				throw new UserAlreadyExistsException("A user with the name '" + name + "' already exists.");

			user = new User();
			user.name = name;
			user.password = password;
			user.level = level;
			Base.Users.Add(user);
			Save(Base.Users);
		}

		public static void Delete(string name) {
			User user = GetByName(name);
			if (user != null)
				Base.Users.Remove(user);
			Save(Base.Users);
		}
		
		public static User GetByName(string name) {
			foreach (User user in Base.Users)
				if (user.name == name)
					return user;
			return null;
		}

	}

	public enum Userlevel {
		Anonymous, User, Administrator
	}
}
