using System;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public interface IDbObject
	{
		int ObjectId { get;}

        string Description { get; set; }
	}
}
