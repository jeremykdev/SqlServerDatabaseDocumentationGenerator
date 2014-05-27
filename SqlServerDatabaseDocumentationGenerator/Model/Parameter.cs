using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class Parameter : IDbObject
    {
        public string ParameterName { get; set; }

        public string DataType { get; set; }

        public int? MaximumLength { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        public string Direction { get; set; }

        public string Description { get; set; }

        public IDbObject Parent { get; set; }

        public int ObjectId { get; set; }

        public string ObjectName { get { return this.ParameterName; } }

        public string ObjectFullDisplayName { get { return this.ParameterName; } }

        public string ObjectTypeDisplayText { get { return String.Format("Parameter of {0}", this.Parent.ObjectFullDisplayName);  } }

    }
}
