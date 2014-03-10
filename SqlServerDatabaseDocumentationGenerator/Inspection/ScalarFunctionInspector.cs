using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ScalarFunctionInspector : CommonInspector
    {

        public ScalarFunctionInspector(PetaPoco.Database petaDb) : base(petaDb)
        {

        }

        public IList<ScalarFunction> GetScalarFunctions(Schema schema)
        {
            IList<ScalarFunction> functionList = null;


            functionList = this.queryForScalarFunctions(schema);

           
            if (functionList != null && functionList.Count > 0)
            {
                var paramInspector = new ParameterInspector(this.peta);

                for (int f = 0; f < functionList.Count; f++)
                {
                    var sf = functionList[f];
                    sf.Parameters = paramInspector.GetParameters(sf);
                    sf.Parent = schema;
                }

            }


            return functionList;

        }

        private IList<ScalarFunction> queryForScalarFunctions(Schema schema)
        {
            var sql = new Sql(@"SELECT  
                                J.[name] AS FunctionName
                                , J.object_id AS FunctionId
                                , EP.value AS [Description]
	                            , R.DATA_TYPE AS ReturnDataType
	                            , R.CHARACTER_MAXIMUM_LENGTH AS ReturnTypeMaximumLength   
	                            , CONVERT(INT, R.NUMERIC_PRECISION) AS ReturnTypePrecision
	                            , CONVERT(INT, R.NUMERIC_SCALE) AS ReturnTypeScale        
	
                            FROM sys.objects AS J
	                            INNER JOIN sys.schemas AS S
		                            ON ( J.schema_id = S.schema_id )
	                            INNER JOIN INFORMATION_SCHEMA.ROUTINES AS R
		                            ON ( R.SPECIFIC_SCHEMA = S.[name] AND R.SPECIFIC_NAME = J.[name] )
                                LEFT OUTER JOIN sys.extended_properties AS EP
                                    ON ( EP.class = 1 AND EP.name = 'MS_Description' AND EP.major_id = J.object_id AND EP.minor_id = 0 )
                          
                            WHERE J.schema_id = @0
	                            AND J.[type] = 'FN'

                            ORDER BY J.[name];", schema.SchemaId);

            return this.peta.Fetch<ScalarFunction>(sql);
        }

    }
}
