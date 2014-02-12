using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    /// <summary>
    /// Database routine object such as a stored procedure or function
    /// </summary>
    public interface IDbRoutine
    {
         IList<Parameter> Parameters { get; set; }

         string Description { get; set; } 
    }
}
