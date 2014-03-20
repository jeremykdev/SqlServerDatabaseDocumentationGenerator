using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Table : IDbObject
	{
		public string TableName { get; set; }

		public string Description { get; set; }

		public int TableId { get; set; }

		public int ObjectId { get { return this.TableId; } }

		public IList<Column> Columns { get; set; }

		public IList<Index> Indexes { get; set; }

        public IList<ForeignKey> ForeignKeys { get; set; }

        public IDbObject Parent { get; set; }

        public string ObjectName { get { return this.TableName; } }
	}
}
