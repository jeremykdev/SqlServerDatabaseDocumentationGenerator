using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{
    /// <summary>
    /// Collection of extension methods related to SQL text
    /// </summary>
    public static class SqlExtension
    {
        /// <summary>
        /// Quote and escape string for use in SQL script as text
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Will treat a null value as an empty string
        /// </remarks>
        public static string ToSqlQuotedText(this string input)
        {
            //remove known potentially dangerous strings
            var sb = new StringBuilder(input.StripSqlUnsafeCharacters());

            sb.Replace("'", "''"); //escape single quotes within text

            //surround text with single quotes
            sb.Insert(0, "'");
            sb.Append("'");

            return sb.ToString();
        }

    

        /// <summary>
        /// Remove potentially dangerous strings from text. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Intended for use when generating SQL script files.  Not as a substitute for parameterized SQL statments.
        /// Based on list from: http://technet.microsoft.com/en-us/library/ms161953(v=SQL.105).aspx
        /// </remarks>
        public static string StripSqlUnsafeCharacters(this string input)
        {
            var escapeList = new string[] { ";", "'", "--", "/*", "*/", "xp_" };
                      

            if (!String.IsNullOrWhiteSpace(input))
            {
                var sb = new StringBuilder(input);

                for (int i = 0; i < escapeList.Length; i++)
                {
                    sb.Replace(escapeList[i], String.Empty);
                }


                return sb.ToString();
            }
            else
            {
                return input;
            }

        }

    }
}
