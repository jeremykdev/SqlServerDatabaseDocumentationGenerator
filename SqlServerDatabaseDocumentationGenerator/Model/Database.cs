using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Database : IDbObject
	{

		public string DatabaseName { get; set; }

		public int ObjectId { get; set; }

		public IList<Schema> Schemas { get; set; }

        public string Description { get; set; }

        //Database does not have a parent object
        public IDbObject Parent { get { return null; } set { } }
        
        public string ObjectName { get { return this.DatabaseName; } }

        public string ObjectFullDisplayName { get { return this.DatabaseName; } }

        public string ObjectTypeDisplayText { get { return "Database"; } }
    }
}
