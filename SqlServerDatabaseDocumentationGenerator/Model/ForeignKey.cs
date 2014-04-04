using System;
using System.Collections.Generic;
using System.Linq;


namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class ForeignKey : IDbObject
    {
        public string ObjectName { get { return this.ForeignKeyName; } }

        public string ObjectFullName { get { return this.ForeignKeyName; } }

        public int  ForeignKeyId { get; set; }

        public string ForeignKeyName { get; set; }

        public int ReferencedObjectId { get; set; }

        public string ReferencedObjectName { get; set; }

        public string ReferencedObjectSchemaName { get; set; }

        public string DeleteReferentialAction { get; set; }

        public string UpdateReferentialAction { get; set; }

        public bool IsDisabled { get; set; }

        public bool IsNotTrusted { get; set; }

        public string Description { get; set; }

        public int ObjectId { get { return this.ForeignKeyId; } }

        public IList<ForeignKeyColumn> ForeignKeyColumns { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectFullDisplayName { get { return this.ObjectFullName; } }

        public string ObjectTypeDisplayText { get { return "Foreign Key"; } }
    }
}
