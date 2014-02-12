using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class Parameter
    {
        public string ParameterName { get; set; }

        public string DataType { get; set; }

        public int? MaximumLength { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        public string Direction { get; set; }

        public string Description { get; set; }
    }
}
