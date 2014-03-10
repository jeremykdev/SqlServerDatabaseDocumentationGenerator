using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class SchemaInspector : CommonInspector
	{

        public SchemaInspector(PetaPoco.Database petaDb) : base(petaDb)
		{
		}


		public IList<Schema> GetSchemas(net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database parent)
		{
			//get schemas
			List<Schema> schemaList = this.queryForSchemas();

			//get tables for each schema
			if (schemaList != null && schemaList.Count > 0)
			{
				var tableInspector = new TableInspector(this.peta);

                var viewInspector = new ViewInspector(this.peta);

                var sprocInspector = new StoredProcedureInspector(this.peta);

                var scalarUdfInspector = new ScalarFunctionInspector(this.peta);

                var tableUdfInspector = new TableFunctionInspector(this.peta);

				Schema schema = null;

				for (int i = 0; i < schemaList.Count; i++)
				{
					schema = schemaList[i];

					schema.Tables = tableInspector.GetTables(schema);
                    schema.Views = viewInspector.GetViews(schema);
                    schema.StoredProcedures = sprocInspector.GetStoredProcedures(schema);
                    schema.ScalarFunctions = scalarUdfInspector.GetScalarFunctions(schema);
                    schema.TableFunctions = tableUdfInspector.GetTableFunctions(schema);

                    schema.Parent = parent;
				}

			}

			return schemaList;
		}

		private List<Schema> queryForSchemas()
		{
			//TODO: add description metadata from extended properties

			var sql = new Sql(@"SELECT S.[name] AS SchemaName
								, S.schema_id AS SchemaId
								, EP.value AS [Description]
						FROM sys.schemas AS S
							LEFT OUTER JOIN sys.extended_properties AS EP
								ON ( S.schema_id = EP.major_id AND EP.name = 'MS_Description' )

						WHERE S.[name] NOT LIKE 'db__%' 
							AND S.[name] NOT IN ( 'sys', 'INFORMATION_SCHEMA' ) 
								
						ORDER BY S.[name];");

			return this.peta.Fetch<Schema>(sql);
		}
	}
}
