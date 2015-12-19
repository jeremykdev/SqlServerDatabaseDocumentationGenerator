using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class View :IDbObject
	{
        public string ObjectName { get { return this.ViewName; } }

		public int ViewId { get; set; }

        public string ViewName { get; set; }

        public string Description { get; set; }

        public IList<Column> Columns { get; set; }

        public IList<Index> Indexes { get; set; }

        public IDbObject Parent { get; set; }

        public bool IsIndexedView
        {
            get 
            { 
                return ( this.Indexes != null && this.Indexes.Count > 0 );
            }
         }


		public int ObjectId { get { return this.ViewId; }
		}

        public string ObjectFullDisplayName { get { return String.Format("{0}.{1}", this.Parent.ObjectName, this.ObjectName); } }

        public string ObjectTypeDisplayText { get { return "View"; } }

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
