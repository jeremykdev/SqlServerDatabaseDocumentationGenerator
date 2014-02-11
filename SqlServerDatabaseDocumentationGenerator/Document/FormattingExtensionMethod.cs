using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document
{
	public static class FormattingExtensionMethod
	{

		public static string ToYesNo(this bool input)
		{
			if (input)
			{
				return "Yes";
			}

			return "No";
		}

	}
}
