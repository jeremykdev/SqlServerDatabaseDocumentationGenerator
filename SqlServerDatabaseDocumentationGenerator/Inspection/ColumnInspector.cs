using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class ColumnInspector: CommonInspector
	{


        public ColumnInspector(PetaPoco.Database petaDb): base(petaDb)
		{
			
		}


		public IList<Column> GetColumns(IDbObject parent)
		{
			IList<Column> result = null;

			if (parent is Table)
			{
				result = this.queryForTableColumns(parent as Table);
			}

            if (parent is View)
            {
                result = this.queryForViewColumns(parent as View);
            }

            if (parent is TableFunction)
            {
                result = this.queryForFunctionColumns(parent as TableFunction);
            }

            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].Parent = parent;
                }
            }

			return result;
		}

        private IList<Column> queryForViewColumns(View view)
        {
            var sql = new Sql(@"SELECT C.name AS ColumnName
						, I.DATA_TYPE AS BaseDataTypeName
						, I.CHARACTER_MAXIMUM_LENGTH AS MaximumLength
						, C.is_nullable AS AllowNull
						, CONVERT(INT, I.NUMERIC_PRECISION) AS Precision
						, CONVERT(INT, I.NUMERIC_SCALE) AS Scale
						, C.object_id AS ColumnId
						, I.COLUMN_DEFAULT AS DefaultValue
						, C.is_identity AS IsIdentity
						, C.is_computed AS IsComputed
                        , Y.name AS TypeName
						, Y.is_user_defined AS IsUserDefinedType

					FROM sys.views AS V	
						INNER JOIN sys.schemas AS S
							ON ( V.schema_id = S.schema_id )
						INNER JOIN sys.columns AS C
							ON ( V.object_id = C.object_id )
						INNER JOIN sys.types AS Y
							ON ( Y.user_type_id  = C.user_type_id )
						INNER JOIN INFORMATION_SCHEMA.COLUMNS AS I
							ON ( I.TABLE_SCHEMA = S.[name] AND I.TABLE_NAME = V.[name] AND I.COLUMN_NAME = C.[name] )
					
					WHERE V.object_id = @0
 
					ORDER BY C.column_id, C.name;", view.ViewId);


            return this.peta.Fetch<Column>(sql);
        }


		private List<Column> queryForTableColumns(Table parentTable)
		{
			

			//petapoco's automapping columns has issues with smallint so we'll explicity convert to int in query
			var sql = new Sql(@"SELECT C.name AS ColumnName
						, EP.value AS [Description]
						, I.DATA_TYPE AS BaseDataTypeName
						, I.CHARACTER_MAXIMUM_LENGTH AS MaximumLength
						, C.is_nullable AS AllowNull
						, CONVERT(INT, I.NUMERIC_PRECISION) AS Precision
						, CONVERT(INT, I.NUMERIC_SCALE) AS Scale
						, C.object_id AS ColumnId
						, I.COLUMN_DEFAULT AS DefaultValue
						, C.is_identity AS IsIdentity
						, C.is_computed AS IsComputed
                        , Y.name AS TypeName
						, Y.is_user_defined AS IsUserDefinedType

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


        private IList<Column> queryForFunctionColumns(TableFunction func)
        {
            var sql = new Sql(@"SELECT 
	                            C.name AS ColumnName
	                            , Y.[name] AS BaseDataTypeName
	                            , C.is_nullable AS AllowNull

                            FROM sys.objects AS T	
	                            INNER JOIN sys.schemas AS S
		                            ON ( T.schema_id = S.schema_id )
	                            INNER JOIN sys.columns AS C
		                            ON ( T.object_id = C.object_id )
	                            INNER JOIN sys.types AS Y
		                            ON ( Y.user_type_id  = C.user_type_id )

                            WHERE T.object_id = @0
	                            AND T.type = 'TF'

                            ORDER BY C.column_id, C.name;", func.FunctionId);

            return this.peta.Fetch<Column>(sql);

        }
	}
}
