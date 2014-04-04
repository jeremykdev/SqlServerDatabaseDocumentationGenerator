using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Index : IDbObject
	{
		public int IndexId { get; set; }

		public int ObjectId { get { return this.IndexId; } }

		public string IndexName { get; set; }

		public IList<string> ColumnNames { get; set; }

		public string Description { get; set; }

		public bool IsPrimaryKey { get; set; }

		public bool IsUnique { get; set; }

		public string IndexTypeDescription { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectName { get { return this.IndexName; } }

        public string ObjectFullDisplayName { get { return this.IndexName; } }

        public string ObjectTypeDisplayText { get { return "Index"; } }
	}
}
