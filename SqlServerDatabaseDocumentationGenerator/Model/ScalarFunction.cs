using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class ScalarFunction: IDbObject, IUserDefinedFunction, IDbRoutine
    {

        public string FunctionName { get; set; }

        public int FunctionId { get; set; }

        public string Description { get; set; }

        public IList<Parameter> Parameters { get; set; }

        public int ObjectId { get { return this.FunctionId; } }

        public string ReturnDataType { get; set; }

        public int? ReturnTypeMaximumLength { get; set; }

        public int? ReturnTypePrecision { get; set; }

        public int? ReturnTypeScale { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectName { get { return this.FunctionName; } }

        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}", this.Parent.ObjectName, this.ObjectName); } }

        public string ObjectTypeDisplayText { get { return "Function (scalar)"; } }
    }
}
