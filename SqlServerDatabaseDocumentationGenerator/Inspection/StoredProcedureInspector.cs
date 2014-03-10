using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class StoredProcedureInspector : CommonInspector
    {

        public StoredProcedureInspector(PetaPoco.Database petaDb):base(petaDb)
		{
			 
		}

        public IList<StoredProcedure> GetStoredProcedures(Schema schema)
        {
            IList<StoredProcedure> spList = null;

            spList = this.queryForStoredProcedures(schema);
            
            if (spList != null && spList.Count > 0)
            {
                var parameterInspector = new ParameterInspector(this.peta);

                for (int p = 0; p < spList.Count; p++)
                {
                    var proc = spList[p];
                    proc.Parameters = parameterInspector.GetParameters(proc);
                    proc.Parent = schema;
                }
            }

            return spList;
        }

        private IList<StoredProcedure> queryForStoredProcedures(Schema schema)
        {
            var sql = new Sql(@"SELECT 
	                            SP.[name] AS ProcedureName
	                            , SP.object_id AS ProcedureId
	                            , EP.value AS [Description]
	
                            FROM sys.procedures AS SP
	                            LEFT OUTER JOIN sys.extended_properties AS EP
		                            ON ( EP.class = 1 AND EP.name = 'MS_Description' AND EP.major_id = SP.object_id AND EP.minor_id = 0 )
	
                             WHERE SP.schema_id = @0

                            ORDER BY SP.[name];", schema.SchemaId);

            return this.peta.Fetch<StoredProcedure>(sql);
        }


    }
}
