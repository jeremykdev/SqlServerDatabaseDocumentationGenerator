using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class ForeignKey : IDbObject
    {
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

        //create new type for Column with Column name and ID to store for columns in table and referenced table
    }
}
