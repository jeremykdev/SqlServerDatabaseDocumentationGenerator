using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    /// <summary>
    /// User defined function.  Can be scalar or table
    /// </summary>
    public interface IUserDefinedFunction
    {

        string FunctionName { get; set; }

        int FunctionId { get; set; }

        string Description { get; set; }

        IList<Parameter> Parameters { get; set; }

    }
}
