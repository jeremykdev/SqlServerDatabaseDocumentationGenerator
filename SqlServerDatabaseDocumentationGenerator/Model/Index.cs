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

		public IList<Column> Columns { get; set; }

		public string Description { get; set; }

		public bool IsPrimaryKey { get; set; }

		public bool IsUnique { get; set; }

		public string IndexTypeDescription { get; set; }
	}
}
