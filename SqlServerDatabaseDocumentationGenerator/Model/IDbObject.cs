using System;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public interface IDbObject
	{
		int ObjectId { get;}

        string Description { get; set; }

        /// <summary>
        /// Parent of current object.  For columns this would be a table or view, For tables this would be a schema, etc.
        /// </summary>
        IDbObject Parent { get; set; }

        string ObjectName { get; }

        /// <summary>
        /// Object's display name
        /// </summary>
        /// <example>dbo.spMySproc for a stored procedure in the 'dbo' schema with name of 'spMySproc'</example>
        string ObjectFullDisplayName { get; }

        /// <summary>
        /// Object type type display text
        /// </summary>
        /// <example>"Table", "Database", etc.</example>
        string ObjectTypeDisplayText { get; }
	}
}
