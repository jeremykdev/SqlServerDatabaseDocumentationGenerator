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
            var result = (from obj in objList
                          where String.IsNullOrWhiteSpace(obj.Description) == true
                          select obj).ToList();


            return result;
        }

    }
}
