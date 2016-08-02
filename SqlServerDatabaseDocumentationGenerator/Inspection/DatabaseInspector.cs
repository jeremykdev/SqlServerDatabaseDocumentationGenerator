using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class DatabaseInspector : CommonInspector
	{

		private SqlConnection sqlConnection;

		private string sqlConnectionString; 

	
		public DatabaseInspector(string connstring)
		{
			
			this.sqlConnectionString = connstring;
			this.sqlConnection = new SqlConnection(this.sqlConnectionString);
		}

		

		public Database GetDatabaseMetaData()
		{
            Database database = null;

            if (SqlConnectionTester.TestConnectionString(this.sqlConnectionString, false).Success)
			{
				this.peta = new PetaPoco.Database(this.sqlConnectionString, "System.Data.SqlClient");


                database = this.queryForDatabase();

				var schemaInspector = new SchemaInspector(this.peta);

				database.Schemas = schemaInspector.GetSchemas(database);

                //TODO: add input parameter to control inspection for design issues
                DesignIssue.DatabaseDesignIssueInspector designIssueInspector = new DesignIssue.DatabaseDesignIssueInspector();
                database.DesignIssueWarnings = designIssueInspector.GetDesignIssueWarnings(database);


			}

			return database;
		}

        private Database queryForDatabase()
        {
            var sql = new PetaPoco.Sql(@"SELECT DatabaseName
	                                        ,  ObjectId
	                                        , EP.value AS [Description]
                                        FROM 
	                                        ( SELECT DB_NAME() AS DatabaseName, DB_ID() AS ObjectId ) AS DbInfo
	                                        LEFT OUTER JOIN sys.extended_properties AS EP
		                                        ON ( EP.class = 0 AND EP.[name] = 'MS_Description' );");

            return this.peta.FirstOrDefault<Database>(sql);
        }

        /*
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


		*/

	}
}
