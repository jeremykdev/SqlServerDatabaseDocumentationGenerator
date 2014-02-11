using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class View :IDbObject
	{

		//TODO: finish

		public int ViewId { get; set; }

		public int ObjectId
		{
			get { throw new NotImplementedException(); }
		}
	}
}
