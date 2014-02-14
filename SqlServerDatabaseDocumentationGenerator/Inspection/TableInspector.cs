using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	class TableInspector
	{
		private PetaPoco.Database peta;

		

		public TableInspector(PetaPoco.Database petaDb)
		{
			this.peta = petaDb;		
		
		}

		public IList<Table> GetTables(Schema schema)
		{
			var tableList = this.queryForTables(schema);

			

			if (tableList != null && tableList.Count > 0)
			{
				Table table = null;

				var columnInspector = new ColumnInspector(this.peta);

				var indexInspector = new IndexInspector(this.peta);

                var foreignKeyInspector = new ForeignKeyInspector(this.peta);

				for (int i = 0; i < tableList.Count; i++)
				{
					table = tableList[i];
					table.Columns = columnInspector.GetColumns(table);
					table.Indexes = indexInspector.GetIndexes(table);
                    table.ForeignKeys = foreignKeyInspector.GetForeignKeys(table);
				}

			}


			return tableList;

		}


		private IList<Table> queryForTables(Schema schema)
		{
			var sql = new Sql(@"SELECT T.name AS TableName
								, COALESCE(EP.value, '') AS [Description]
								, T.object_id AS TableId

							FROM sys.tables AS T
								LEFT OUTER JOIN sys.extended_properties AS EP
									ON ( EP.major_id = T.object_id AND EP.minor_id = 0 AND EP.name = 'MS_Description' )

							WHERE T.schema_id = @0
 
							ORDER BY T.name", schema.SchemaId);

			return this.peta.Fetch<Table>(sql);
		}
	}
}
