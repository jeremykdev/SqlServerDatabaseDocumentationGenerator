using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document
{
    /// <summary>
    /// Configuration options for document generation
    /// </summary>
    public class DocumentGeneratorConfiguration
    {
        public bool ForeignKeyToTableHyperLink { get; set; }

        public bool CheckForDesignIssues { get; set; }
    }
}
