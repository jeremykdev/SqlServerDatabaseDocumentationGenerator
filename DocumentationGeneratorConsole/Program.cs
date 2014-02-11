using System;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document;

namespace net.datacowboy.DocumentationGeneratorConsole
{
	class Program
	{
		static void Main(string[] args)
		{

			//TODO: add param support
			string connStr = "Server=.; Database=AdventureWorks; Integrated Security=true;";

			DatabaseInspector dbi = new DatabaseInspector(connStr);
			var metadata = dbi.GetDatabaseMetaData();

			

			DatabaseHtmlDocumentGenerator gen = new DatabaseHtmlDocumentGenerator();

			using (var sw = new StreamWriter("database.html", false))
			{
				var str = gen.ExportToHtml(metadata, sw);
			}

			Console.ReadLine();

		}
	}
}
