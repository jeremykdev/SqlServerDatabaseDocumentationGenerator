using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Check if a set is not null and has any members
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasAny<T>(this IEnumerable<T> input)
        {
            return (input != null && input.Any());
        }

    }
}
