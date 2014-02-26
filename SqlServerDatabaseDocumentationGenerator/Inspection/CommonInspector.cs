using System;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    /// <summary>
    /// Base class for inspectors
    /// </summary>
    public abstract class CommonInspector
    {
        protected Database peta;

        public CommonInspector(Database petaDb)
        {
            this.peta = petaDb;
        }

        public CommonInspector()
        {
            //if petapoco database object not passed in constructor object should build one
        }
    }
}
