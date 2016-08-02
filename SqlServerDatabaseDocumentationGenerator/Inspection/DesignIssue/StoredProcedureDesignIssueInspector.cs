using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection.DesignIssue
{
    public class StoredProcedureDesignIssueInspector
    {

        

        public List<DesignIssueWarning> GetDesignIssueWarning(Model.Database database)
        {
            List<DesignIssueWarning> warningList = new List<DesignIssueWarning>();

            if (database == null || !database.Schemas.HasAny())
            {
                return null; //cannot act on empty object
            }

            this.checkForNameStartingWithSpUndercoreWarning(database, ref warningList);
            

            //TODO: finish

            return warningList;

        }

        /// <summary>
        /// Handles checking for stored procedures with name starting with 'sp_;
        /// </summary>
        /// <param name="database">Database to examine</param>
        /// <param name="warningList">List to add to if issues found</param>
        private void checkForNameStartingWithSpUndercoreWarning(Database database, ref List<DesignIssueWarning> warningList)
        {
            if (database == null || !database.Schemas.HasAny())
            {
                return;
            }

            var problems = (
                    from schema in database.Schemas
                    from sproc in schema.StoredProcedures
                    where sproc.ObjectName.StartsWith("sp_", StringComparison.OrdinalIgnoreCase)
                    select sproc as IDbObject
                ).ToList();

            if (problems.HasAny())
            {
                DesignIssueWarning sprocNameWarning = new DesignIssueWarning()
                {
                    Description = "Stored Procedures with name staring with 'sp_' are not recommended",
                    ReferenceUrl = new Uri("https://msdn.microsoft.com/en-us/library/ms190669(v=sql.105).aspx"),
                    DatabaseObjects = problems 
                };

                warningList.Add(sprocNameWarning);


            }
        }

        
        

        

    }
}
