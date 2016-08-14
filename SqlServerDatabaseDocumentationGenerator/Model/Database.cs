using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
    public class Database : IDbObject
    {

        public string DatabaseName { get; set; }

        public int ObjectId { get; set; }

        public IList<Schema> Schemas { get; set; }

        public string Description { get; set; }

        //Database does not have a parent object
        public IDbObject Parent { get { return null; } set { } }

        public string ObjectName { get { return this.DatabaseName; } }

        public string ObjectFullDisplayName { get { return this.DatabaseName; } }

        public string ObjectTypeDisplayText { get { return "Database"; } }

        public IList<DesignIssueWarning> DesignIssueWarnings { get; set; }

        /// <summary>
        /// Get all IDbOjects in database in one list
        /// </summary>
        /// <returns></returns>
        public IList<IDbObject> GetAllObjects()
        {
            List<IDbObject> allDbObjList = new List<IDbObject>();


            var schemas = (
                    from s in this.Schemas
                    select s as IDbObject
                ).ToList();

            allDbObjList.AddRange(schemas);

            var tables = (
                   from s in this.Schemas
                   from obj in s.Tables
                   select obj as IDbObject
               ).ToList();

            allDbObjList.AddRange(tables);

            var sprocs = (
                    from s in this.Schemas
                    from obj in s.StoredProcedures
                    select obj as IDbObject
                ).ToList();

            if (sprocs.HasAny())
            {
                var sprocParams = (
                        from sc in this.Schemas
                        from sproc in sc.StoredProcedures
                        from param in sproc.Parameters
                        select param as IDbObject
                    ).ToList();

                allDbObjList.AddRange(sprocParams);
            }

            allDbObjList.AddRange(sprocs);

            var scalarFuncs = (
                    from s in this.Schemas
                    from obj in s.ScalarFunctions
                    select obj as IDbObject
                ).ToList();

            if (scalarFuncs.HasAny())
            {
                var scalarFuncParams = (
                        from s in this.Schemas
                        from func in s.ScalarFunctions
                        from param in func.Parameters
                        select param as IDbObject 
                    ).ToList();

                allDbObjList.AddRange(scalarFuncParams);

            }

            allDbObjList.AddRange(scalarFuncs);


            var tableFuncs = (
                    from s in this.Schemas
                    from obj in s.TableFunctions
                    select obj as IDbObject
                ).ToList();

            if (tableFuncs.HasAny())
            {
                var tfParams = (
                        from s in this.Schemas
                        from tfunc in s.TableFunctions
                        from param in tfunc.Parameters
                        select param as IDbObject
                    ).ToList();

                allDbObjList.AddRange(tfParams);


                var tfCols = (
                        from s in this.Schemas
                        from tfunc in s.TableFunctions
                        from param in tfunc.Parameters
                        select param as IDbObject
                    ).ToList();

                allDbObjList.AddRange(tfCols);

            }

            allDbObjList.AddRange(tableFuncs);


            return allDbObjList;

        }
    }
}
