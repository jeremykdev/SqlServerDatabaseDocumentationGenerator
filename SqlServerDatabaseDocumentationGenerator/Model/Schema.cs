using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Schema : IDbObject
	{
        public string ObjectName { get { return this.SchemaName; } }

        public string ObjectFullDisplayName { get { return this.ObjectName; } }

		public string SchemaName { get; set; }

		public int SchemaId { get; set; }

		public string Description { get; set; }

		public IList<Table> Tables { get; set; }

        public IList<View> Views { get; set; }

        public IList<StoredProcedure> StoredProcedures { get; set; }

        public IList<ScalarFunction> ScalarFunctions { get; set; }

        public IList<TableFunction> TableFunctions { get; set; }

		public int ObjectId { get { return this.SchemaId; } }

        public IDbObject Parent { get; set; }

        public string ObjectTypeDisplayText { get { return "Schema"; } }
	}
}
