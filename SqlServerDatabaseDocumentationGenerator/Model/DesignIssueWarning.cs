using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class DesignIssueWarning
    {
        public List<IDbObject> DatabaseObjects { get; set; }

        public string Description { get; set; }

        public Uri ReferenceUrl { get; set; }

        
    
    }
}
