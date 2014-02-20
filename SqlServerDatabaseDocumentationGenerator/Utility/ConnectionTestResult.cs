using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{

	public class ConnectionTestResult
	{
		public bool Success { get; set; }

		public string ErrorMessage { get; set; }
	}
}
