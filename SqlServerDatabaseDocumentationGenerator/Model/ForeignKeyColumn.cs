using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    /// <summary>
    /// Column reference in foriegn key parent to reference
    /// </summary>
    public class ForeignKeyColumn
    {

        public int ParentColumnId { get; set; }

        public string ParentColumnName { get; set; }

        public int ReferenceColumnId { get; set; }

        public string ReferenceColumnName { get; set; }

        public int ConstraintColumnId { get; set; }

    }
}
