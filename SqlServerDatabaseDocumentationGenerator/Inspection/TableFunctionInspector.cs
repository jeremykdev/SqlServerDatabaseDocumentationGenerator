using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    class TableFunctionInspector : CommonInspector
    {
      

        public TableFunctionInspector(PetaPoco.Database petaDb):base(petaDb)	
        {
	      
        }


        public IList<TableFunction> GetTableFunctions(Schema schema)
        {
            IList<TableFunction> tfList = this.queryForTableFunctions(schema);


            if (tfList != null && tfList.Count > 0)
            {

                var paramInspector = new ParameterInspector(this.peta);

                var columnInspector = new ColumnInspector(this.peta);

                for (int t = 0; t < tfList.Count; t++)
                {

                    var func = tfList[t];

                    func.Parameters = paramInspector.GetParameters(func);

                    func.Columns = columnInspector.GetColumns(func);

                    func.Parent = schema;
                }
                
            }

            return tfList;

        }

        private IList<TableFunction> queryForTableFunctions(Schema schema)
        {
            var sql = new Sql(@"SELECT  
                                J.[name] AS FunctionName
                                , J.object_id AS FunctionId
                                , EP.value AS [Description]
	                           	
                            FROM sys.objects AS J
	                            INNER JOIN sys.schemas AS S
		                            ON ( J.schema_id = S.schema_id )
	                            INNER JOIN INFORMATION_SCHEMA.ROUTINES AS R
		                            ON ( R.SPECIFIC_SCHEMA = S.[name] AND R.SPECIFIC_NAME = J.[name] )
                                LEFT OUTER JOIN sys.extended_properties AS EP
                                    ON ( EP.class = 1 AND EP.name = 'MS_Description' AND EP.major_id = J.object_id AND EP.minor_id = 0 )
                          
                            WHERE J.schema_id = @0
	                            AND J.[type] IN ( 'TF', 'IF' )

                            ORDER BY J.[name];", schema.SchemaId);

            return this.peta.Fetch<TableFunction>(sql);
        }
    }
}
