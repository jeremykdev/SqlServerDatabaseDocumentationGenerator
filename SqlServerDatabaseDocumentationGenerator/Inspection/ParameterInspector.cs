using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ParameterInspector: CommonInspector
    {

        public ParameterInspector(PetaPoco.Database petaDb) : base(petaDb)
		{
		
		}

        public IList<Parameter> GetParameters(IDbRoutine routine)
        {

            IList<Parameter> results = null;

            if (routine is StoredProcedure)
            {
                results = this.queryForStoredProcedureParameters(routine as StoredProcedure);
            }
            else
            {
                if (routine is IUserDefinedFunction)
                {

                    results = this.queryForUserDefinedFunctionParameters(routine as IUserDefinedFunction);
                }

            }


            if (results != null && results.Count > 0 && routine is IDbObject)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    results[i].Parent = routine as IDbObject;
                }
            }

            return results;
        }

        private IList<Parameter> queryForUserDefinedFunctionParameters(IUserDefinedFunction func)
        {
            var sql = new Sql(@"SELECT 
	                                PM.name AS ParameterName 
                                    , IP.CHARACTER_MAXIMUM_LENGTH AS [MaximumLength] 
                                    , CONVERT(INT, IP.NUMERIC_PRECISION) AS Precision
                                    , CONVERT(INT, IP.NUMERIC_SCALE) AS Scale 
                                    , IP.DATA_TYPE AS DataType 
                                    , EP.value AS [Description]
   
                                FROM sys.objects AS J 
                                    INNER JOIN sys.parameters AS PM 
                                        ON ( J.object_id = PM.object_id ) 
                                    INNER JOIN sys.schemas AS S 
                                        ON ( J.schema_id = S.schema_id ) 
                                    INNER JOIN INFORMATION_SCHEMA.PARAMETERS AS IP 
                                        ON ( IP.SPECIFIC_SCHEMA = S.[name] AND IP.SPECIFIC_NAME = J.[name] AND IP.PARAMETER_NAME = PM.[name] ) 
                                    LEFT OUTER JOIN sys.extended_properties AS EP
                                        ON ( EP.class = 2 AND EP.[name] = 'MS_Description' AND EP.major_id = J.object_id AND EP.minor_id = PM.parameter_id ) 

                                WHERE J.object_id = @0 
	                               AND IP.IS_RESULT = 'NO'
                                   AND J.[type] IN ( 'FN', 'TF' )

                                ORDER BY IP.ORDINAL_POSITION, IP.PARAMETER_NAME;", func.FunctionId);

            return this.peta.Fetch<Parameter>(sql);
        }

        private IList<Parameter> queryForStoredProcedureParameters(StoredProcedure proc)
        {

           var sql = new Sql(@"SELECT 
                                    PM.name AS ParameterName 
                                    , IP.CHARACTER_MAXIMUM_LENGTH AS [MaximumLength] 
                                    , CONVERT(INT, IP.NUMERIC_PRECISION) AS Precision
						            , CONVERT(INT, IP.NUMERIC_SCALE) AS Scale 
                                    , IP.DATA_TYPE AS DataType 
                                    , CASE 
                                        WHEN PM.is_output = 1 
                                            THEN 'Output' 
                                        ELSE 'Input'     
                                    END AS Direction 
                                    , EP.value AS [Description]

                                FROM sys.procedures AS SP 
                                    INNER JOIN sys.parameters AS PM 
                                        ON ( SP.object_id = PM.object_id ) 
                                    INNER JOIN sys.schemas AS S 
                                        ON ( SP.schema_id = S.schema_id ) 
                                    INNER JOIN INFORMATION_SCHEMA.PARAMETERS AS IP 
                                        ON ( IP.SPECIFIC_SCHEMA = S.[name] AND IP.SPECIFIC_NAME = SP.[name] AND IP.PARAMETER_NAME = PM.[name] ) 
                                    LEFT OUTER JOIN sys.extended_properties AS EP
		                                ON ( EP.class = 2 AND EP.[name] = 'MS_Description' AND EP.major_id = SP.object_id AND EP.minor_id = PM.parameter_id ) 

                                WHERE SP.object_id = @0 

                                ORDER BY IP.ORDINAL_POSITION, IP.PARAMETER_NAME;", proc.ProcedureId);

            return this.peta.Fetch<Parameter>(sql);
        }
    }
}

/*

SELECT 
    PM.name AS ParameterName 
    , PM.max_length AS [MaximumLength] 
    , PM.precision AS [Precision] 
    , PM.scale AS [Scale] 
    , IP.DATA_TYPE AS DataType 
    , CASE 
        WHEN PM.is_output = 1 
            THEN 'Output' 
        ELSE 'Input'     
    END AS Direction 

     
FROM sys.procedures AS SP 
    INNER JOIN sys.parameters AS PM 
        ON ( SP.object_id = PM.object_id ) 
    INNER JOIN sys.schemas AS S 
        ON ( SP.schema_id = S.schema_id ) 
    INNER JOIN INFORMATION_SCHEMA.PARAMETERS AS IP 
        ON ( IP.SPECIFIC_SCHEMA = S.[name] AND IP.SPECIFIC_NAME = SP.[name] ) 

WHERE SP.object_id = @0 

ORDER BY IP.ORDINAL_POSITION, IP.PARAMETER_NAME; 


*/