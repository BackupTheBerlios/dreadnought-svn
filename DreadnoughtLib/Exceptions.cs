using System;
using System.Collections.Generic;
using System.Text;

namespace Dreadnought {

	public class PageDoesNotExistException : Exception {
		public PageDoesNotExistException(string message) : base(message) { }
	}

	public class InvalidDirectoryException : Exception {
		public InvalidDirectoryException(string message) : base(message) { }
	}

}
