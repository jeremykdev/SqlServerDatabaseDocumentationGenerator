using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class TableFunction : IDbObject, IDbRoutine, IUserDefinedFunction
    {
        public string FunctionName { get; set; }

        public int FunctionId { get; set; }

        public string Description { get; set; }

        public IList<Parameter> Parameters { get; set; }

        public int ObjectId { get { return this.FunctionId; } }

        public IList<Column> Columns { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectName { get { return this.FunctionName; } }

        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}", this.Parent.ObjectName, this.ObjectName); } }

        public string ObjectTypeDisplayText { get { return "Function (table)"; } }
    }
}
