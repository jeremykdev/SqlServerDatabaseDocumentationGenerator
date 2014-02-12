using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ParameterInspector
    {
         private PetaPoco.Database peta;

        public ParameterInspector(PetaPoco.Database petaDb)
		{
			this.peta = petaDb;
		}

        public IList<Parameter> GetParameters(IDbRoutine routine)
        {

            IList<Parameter> results = null;

            if(routine is StoredProcedure)
            {
                results = this.queryForStoredProcedureParameters(routine as StoredProcedure);
            }

            //TODO: support functions


            return results;
        }

        private IList<Parameter> queryForStoredProcedureParameters(StoredProcedure proc)
        {
            var sql = new Sql(@"SELECT 
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