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

        //the TypeName value will be the same as BaseDataTypeName, unless this column data type is a user defined type
        public string TypeName { get; set; }

        public bool IsUserDefinedType { get; set; }

        public IDbObject Parent { get; set; }

        //Display column names as Schema.TableName.ColumnName
        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}.{2}", this.Parent.Parent.ObjectName, this.Parent.ObjectName, this.ColumnName); } }

        public string ObjectName  { get { return this.ColumnName; } }

        public string ObjectTypeDisplayText { get { return "Column"; } }
       
    }
}
