using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class StoredProcedure : IDbObject, IDbRoutine
    {
        public string ProcedureName {get;set; }

        public int ProcedureId {get;set; }

        public int ObjectId { get { return this.ProcedureId; } }

        public string Description { get; set; }

        public IList<Parameter> Parameters { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectName { get { return this.ProcedureName; } }

        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}", this.Parent.ObjectName, this.ObjectName); } }

        public string ObjectTypeDisplayText { get { return "Stored Procedure"; } }
        
    }
}
