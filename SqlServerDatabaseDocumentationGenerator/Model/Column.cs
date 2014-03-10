using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class Column : IDbObject
	{
		

		public string ColumnName { get; set; }

		/// <summary>
		/// Built in data type or data type from which user defined type derives
		/// </summary>
		public string BaseDataTypeName { get; set; }

		public int? MaximumLength { get; set; }

		public int? Precision { get; set; }

		public int? Scale { get; set; }

		public bool AllowNull { get; set; }

		public string Description { get; set; }

		public int ColumnId { get; set; }

		public int ObjectId { get { return this.ColumnId; } }

		public string DefaultValue { get; set; }

		public bool IsIdentity { get; set; }

		public bool IsComputed { get; set; }

        public IDbObject Parent { get; set; }

	}
}
