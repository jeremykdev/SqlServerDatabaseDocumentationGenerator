using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Schema : IDbObject
	{
		public string SchemaName { get; set; }

		public int SchemaId { get; set; }

		public string Description { get; set; }

		public IList<Table> Tables { get; set; }

		public int ObjectId { get { return this.SchemaId; } }
	}
}
