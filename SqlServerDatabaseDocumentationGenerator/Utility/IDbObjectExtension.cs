using System;
using System.Collections.Generic;
using System.Linq;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{
    /// <summary>
    /// Collection of extension methods for IDbObject
    /// </summary>
    public static class IDbObjectExtension
    {
        
        public static IList<IDbObject> FindObjectsWithoutDescription(this IList<IDbObject> objList)
        {
            return (from obj in objList
                          where String.IsNullOrWhiteSpace(obj.Description) == true
                          select obj).ToList();


            
        }

        public static IList<IDbObject> FindObjectsWithoutDescriptionInDatabase(this Database database)
        {
            var objList = new List<IDbObject>();

            if (String.IsNullOrWhiteSpace(database.Description))
            {
                objList.Add(database);
            }

            if (database.Schemas != null && database.Schemas.Count > 0)
            {
                for (int i = 0; i < database.Schemas.Count; i++)
                {
                    objList.AddRange(database.Schemas[i].FindObjectsWithoutDescriptionInSchema());
                }
            }

            return objList;

        }

        public static IList<IDbObject> FindObjectsWithoutDescriptionInSchema(this Schema schema)
        {
            var objList = new List<IDbObject>();

            if (schema.Tables != null && schema.Tables.Count > 0)
            {
                objList.AddRange(schema.Tables.ToArray<IDbObject>().FindObjectsWithoutDescription());
                
                //get columns
                for (int t = 0; t < schema.Tables.Count; t++)
                {
                    var table = schema.Tables[t];
                    objList.AddRange(table.Columns.ToArray<IDbObject>().FindObjectsWithoutDescription());
                }

            }

            if (schema.Views.HasAny())
            {
                objList.AddRange(schema.Views.ToArray<IDbObject>().FindObjectsWithoutDescription());
            }

            if (schema.StoredProcedures.HasAny())
            {

                var spList = schema.StoredProcedures.ToArray<IDbObject>().FindObjectsWithoutDescription();

                if (spList.HasAny())
                {
                    for (int p = 0; p < spList.Count(); p++)
                    {
                        objList.Add(spList[p]);

                        StoredProcedure sproc = spList[p] as StoredProcedure;

                        var paramList = sproc.Parameters.ToArray<IDbObject>().FindObjectsWithoutDescription();

                        if (paramList.HasAny())
                        {
                            objList.AddRange(paramList);
                        }

                    }
                }



            }

            if (schema.TableFunctions.HasAny() )
            {
                objList.AddRange(schema.TableFunctions.ToArray<IDbObject>().FindObjectsWithoutDescription());
            }

            if (schema.ScalarFunctions.HasAny())
            {
                objList.AddRange(schema.ScalarFunctions.ToArray<IDbObject>().FindObjectsWithoutDescription());
            }

            return objList;

        }

    }
}
