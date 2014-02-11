using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class ColumnInspector
	{
		private PetaPoco.Database peta;

		public ColumnInspector(PetaPoco.Database petaDb)
		{
			this.peta = petaDb;
		}


		public IList<Column> GetColumns(IDbObject parent)
		{
			IList<Column> result = null;

			if (parent is Table)
			{
				result = this.queryForTableColumns(parent as Table);
			}

			//TODO: support views

			return result;
		}


		private List<Column> queryForTableColumns(Table parentTable)
		{
			

			//petapoco's automapping columns has issues with smallint so we'll explicity convert to int in query
			var sql = new Sql(@"SELECT C.name AS ColumnName
						, EP.value AS [Description]
						, I.DATA_TYPE AS BaseDataTypeName
						, CONVERT(INT, C.max_length) AS MaximumLength
						, C.is_nullable AS AllowNull
						, CONVERT(INT, C.precision) AS Precision
						, CONVERT(INT, C.scale) AS Scale
						, C.object_id AS ColumnId
						, I.COLUMN_DEFAULT AS DefaultValue
						, C.is_identity AS IsIdentity
						, C.is_computed AS IsComputed

					FROM sys.tables AS T	
						INNER JOIN sys.schemas AS S
							ON ( T.schema_id = S.schema_id )
						INNER JOIN sys.columns AS C
							ON ( T.object_id = C.object_id )
						INNER JOIN sys.types AS Y
							ON ( Y.user_type_id  = C.user_type_id )
						INNER JOIN INFORMATION_SCHEMA.COLUMNS AS I
							ON ( I.TABLE_SCHEMA = S.[name] AND I.TABLE_NAME = T.[name] AND I.COLUMN_NAME = C.[name] )
						LEFT OUTER JOIN sys.extended_properties AS EP
							ON ( EP.class = 1 AND EP.major_id = C.object_id AND EP.minor_id = C.column_id AND EP.name = 'MS_Description' )

					WHERE T.object_id = @0
 
					ORDER BY C.column_id, C.name;", parentTable.TableId);

			return this.peta.Fetch<Column>(sql);
		}
	}
}
