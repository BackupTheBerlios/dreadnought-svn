using System;
using System.Collections.Generic;
using System.Text;

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





	}
}
