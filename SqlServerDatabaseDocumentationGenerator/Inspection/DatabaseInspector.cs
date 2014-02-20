using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class DatabaseInspector
	{

		private SqlConnection sqlConnection;

		private string sqlConnectionString; 

		private PetaPoco.Database peta;

		

		public DatabaseInspector(string connstring)
		{
			
			this.sqlConnectionString = connstring;
			this.sqlConnection = new SqlConnection(this.sqlConnectionString);
		}

		

		public Database GetDatabaseMetaData()
		{
			var database = new Database();

            if (SqlConnectionTester.TestConnectionString(this.sqlConnectionString, false).Success)
			{
				this.peta = new PetaPoco.Database(this.sqlConnectionString, "System.Data.SqlClient");

				
				database.DatabaseName = this.getDatabaseName();
				database.ObjectId = this.getDatabaseId();

				var schemaInspector = new SchemaInspector(this.peta);

				database.Schemas = schemaInspector.GetSchemas();

			}

			return database;
		}

		/// <summary>
		/// Lookup name of current database
		/// </summary>
		/// <returns></returns>
		private string getDatabaseName()
		{
			var sql = new PetaPoco.Sql("SELECT DB_NAME();");
			return this.peta.ExecuteScalar<string>(sql);
		}


		private int getDatabaseId()
		{
			var sql = new PetaPoco.Sql("SELECT DB_ID();");
			return this.peta.ExecuteScalar<int>(sql);
		}


		

	}
}
