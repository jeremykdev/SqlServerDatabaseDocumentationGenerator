using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

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

        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}", this.Parent.ObjectName, this.ObjectName); } }

        public string ObjectTypeDisplayText { get { return "Table"; } }

        /// <summary>
        /// Check if the table has any columns which use a user defined data type
        /// </summary>
        /// <returns></returns>
        public bool ContainsColumnsWithUserDefinedDataType()
        {
            bool result = false;

            if (this.Columns.HasAny())
            {
                if (this.Columns.Where(c => c.IsUserDefinedType).Any())
                {
                    result = true;
                }
            }

            return result;
        }
	}
}
