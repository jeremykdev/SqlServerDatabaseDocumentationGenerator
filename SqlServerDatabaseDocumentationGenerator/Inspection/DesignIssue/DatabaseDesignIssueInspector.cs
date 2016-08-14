using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection.DesignIssue
{
    /// <summary>
    /// Examines database for potential design issues
    /// </summary>
    /// <remarks>
    /// Design issues include things like 
    /// Naming stored procedures with 'sp_*'
    /// Naming objects using SQL server reserved keywords
    /// </remarks>
    public class DatabaseDesignIssueInspector
    {

        private StoredProcedureDesignIssueInspector sprocInspector = new StoredProcedureDesignIssueInspector();

        /// <summary>
        /// Reserve words in SQL Server
        /// </summary>
        /// <remarks>
        /// See: https://msdn.microsoft.com/en-us/library/ms189822.aspx
        /// </remarks>
        private readonly string[] reservedWords = new string[] {
                "ADD",
                "EXISTS",
                "PRECISION",
                "ALL",
                "EXIT",
                "PRIMARY",
                "ALTER",
                "EXTERNAL",
                "PRINT",
                "AND",
                "FETCH",
                "PROC",
                "ANY",
                "FILE",
                "PROCEDURE",
                "AS",
                "FILLFACTOR",
                "PUBLIC",
                "ASC",
                "FOR",
                "RAISERROR",
                "AUTHORIZATION",
                "FOREIGN",
                "READ",
                "BACKUP",
                "FREETEXT",
                "READTEXT",
                "BEGIN",
                "FREETEXTTABLE",
                "RECONFIGURE",
                "BETWEEN",
                "FROM",
                "REFERENCES",
                "BREAK",
                "FULL",
                "REPLICATION",
                "BROWSE",
                "FUNCTION",
                "RESTORE",
                "BULK",
                "GOTO",
                "RESTRICT",
                "BY",
                "GRANT",
                "RETURN",
                "CASCADE",
                "GROUP",
                "REVERT",
                "CASE",
                "HAVING",
                "REVOKE",
                "CHECK",
                "HOLDLOCK",
                "RIGHT",
                "CHECKPOINT",
                "IDENTITY",
                "ROLLBACK",
                "CLOSE",
                "IDENTITY_INSERT",
                "ROWCOUNT",
                "CLUSTERED",
                "IDENTITYCOL",
                "ROWGUIDCOL",
                "COALESCE",
                "IF",
                "RULE",
                "COLLATE",
                "IN",
                "SAVE",
                "COLUMN",
                "INDEX",
                "SCHEMA",
                "COMMIT",
                "INNER",
                "SECURITYAUDIT",
                "COMPUTE",
                "INSERT",
                "SELECT",
                "CONSTRAINT",
                "INTERSECT",
                "SESSION_USER",
                "CONTAINS",
                "INTO",
                "SET",
                "CONTAINSTABLE",
                "IS",
                "SETUSER",
                "CONTINUE",
                "JOIN",
                "SHUTDOWN",
                "CONVERT",
                "KEY",
                "SOME",
                "CREATE",
                "KILL",
                "STATISTICS",
                "CROSS",
                "LEFT",
                "SYSTEM_USER",
                "CURRENT",
                "LIKE",
                "TABLE",
                "CURRENT_DATE",
                "LINENO",
                "TABLESAMPLE",
                "CURRENT_TIME",
                "LOAD",
                "TEXTSIZE",
                "CURRENT_TIMESTAMP",
                "MERGE",
                "THEN",
                "CURRENT_USER",
                "NATIONAL",
                "TO",
                "CURSOR",
                "NOCHECK",
                "TOP",
                "DATABASE",
                "NONCLUSTERED",
                "TRAN",
                "DBCC",
                "NOT",
                "TRANSACTION",
                "DEALLOCATE",
                "NULL",
                "TRIGGER",
                "DECLARE",
                "NULLIF",
                "TRUNCATE",
                "DEFAULT",
                "OF",
                "TSEQUAL",
                "DELETE",
                "OFF",
                "UNION",
                "DENY",
                "OFFSETS",
                "UNIQUE",
                "DESC",
                "ON",
                "UNPIVOT",
                "DISK",
                "OPEN",
                "UPDATE",
                "DISTINCT",
                "OPENDATASOURCE",
                "UPDATETEXT",
                "DISTRIBUTED",
                "OPENQUERY",
                "USE",
                "DOUBLE",
                "OPENROWSET",
                "USER",
                "DROP",
                "OPENXML",
                "VALUES",
                "DUMP",
                "OPTION",
                "VARYING",
                "ELSE",
                "OR",
                "VIEW",
                "END",
                "ORDER",
                "WAITFOR",
                "ERRLVL",
                "OUTER",
                "WHEN",
                "ESCAPE",
                "OVER",
                "WHERE",
                "EXCEPT",
                "PERCENT",
                "WHILE",
                "EXEC",
                "PIVOT",
                "WITH",
                "EXECUTE",
                "PLAN",
                "WRITETEXT",
                "ABSOLUTE",
                "EXEC",
                "OVERLAPS",
                "ACTION",
                "EXECUTE",
                "PAD",
                "ADA",
                "EXISTS",
                "PARTIAL",
                "ADD",
                "EXTERNAL",
                "PASCAL",
                "ALL",
                "EXTRACT",
                "POSITION",
                "ALLOCATE",
                "FALSE",
                "PRECISION",
                "ALTER",
                "FETCH",
                "PREPARE",
                "AND",
                "FIRST",
                "PRESERVE",
                "ANY",
                "FLOAT",
                "PRIMARY",
                "ARE",
                "FOR",
                "PRIOR",
                "AS",
                "FOREIGN",
                "PRIVILEGES",
                "ASC",
                "FORTRAN",
                "PROCEDURE",
                "ASSERTION",
                "FOUND",
                "PUBLIC",
                "AT",
                "FROM",
                "READ",
                "AUTHORIZATION",
                "FULL",
                "REAL",
                "AVG",
                "GET",
                "REFERENCES",
                "BEGIN",
                "GLOBAL",
                "RELATIVE",
                "BETWEEN",
                "GO",
                "RESTRICT",
                "BIT",
                "GOTO",
                "REVOKE",
                "BIT_LENGTH",
                "GRANT",
                "RIGHT",
                "BOTH",
                "GROUP",
                "ROLLBACK",
                "BY",
                "HAVING",
                "ROWS",
                "CASCADE",
                "HOUR",
                "SCHEMA",
                "CASCADED",
                "IDENTITY",
                "SCROLL",
                "CASE",
                "IMMEDIATE",
                "SECOND",
                "CAST",
                "IN",
                "SECTION",
                "CATALOG",
                "INCLUDE",
                "SELECT",
                "CHAR",
                "INDEX",
                "SESSION",
                "CHAR_LENGTH",
                "INDICATOR",
                "SESSION_USER",
                "CHARACTER",
                "INITIALLY",
                "SET",
                "CHARACTER_LENGTH",
                "INNER",
                "SIZE",
                "CHECK",
                "INPUT",
                "SMALLINT",
                "CLOSE",
                "INSENSITIVE",
                "SOME",
                "COALESCE",
                "INSERT",
                "SPACE",
                "COLLATE",
                "INT",
                "SQL",
                "COLLATION",
                "INTEGER",
                "SQLCA",
                "COLUMN",
                "INTERSECT",
                "SQLCODE",
                "COMMIT",
                "INTERVAL",
                "SQLERROR",
                "CONNECT",
                "INTO",
                "SQLSTATE",
                "CONNECTION",
                "IS",
                "SQLWARNING",
                "CONSTRAINT",
                "ISOLATION",
                "SUBSTRING",
                "CONSTRAINTS",
                "JOIN",
                "SUM",
                "CONTINUE",
                "KEY",
                "SYSTEM_USER",
                "CONVERT",
                "LANGUAGE",
                "TABLE",
                "CORRESPONDING",
                "LAST",
                "TEMPORARY",
                "COUNT",
                "LEADING",
                "THEN",
                "CREATE",
                "LEFT",
                "TIME",
                "CROSS",
                "LEVEL",
                "TIMESTAMP",
                "CURRENT",
                "LIKE",
                "TIMEZONE_HOUR",
                "CURRENT_DATE",
                "LOCAL",
                "TIMEZONE_MINUTE",
                "CURRENT_TIME",
                "LOWER",
                "TO",
                "CURRENT_TIMESTAMP",
                "MATCH",
                "TRAILING",
                "CURRENT_USER",
                "MAX",
                "TRANSACTION",
                "CURSOR",
                "MIN",
                "TRANSLATE",
                "DATE",
                "MINUTE",
                "TRANSLATION",
                "DAY",
                "MODULE",
                "TRIM",
                "DEALLOCATE",
                "MONTH",
                "TRUE",
                "DEC",
                "NAMES",
                "UNION",
                "DECIMAL",
                "NATIONAL",
                "UNIQUE",
                "DECLARE",
                "NATURAL",
                "UNKNOWN",
                "DEFAULT",
                "NCHAR",
                "UPDATE",
                "DEFERRABLE",
                "NEXT",
                "UPPER",
                "DEFERRED",
                "NO",
                "USAGE",
                "DELETE",
                "NONE",
                "USER",
                "DESC",
                "NOT",
                "USING",
                "DESCRIBE",
                "NULL",
                "VALUE",
                "DESCRIPTOR",
                "NULLIF",
                "VALUES",
                "DIAGNOSTICS",
                "NUMERIC",
                "VARCHAR",
                "DISCONNECT",
                "OCTET_LENGTH",
                "VARYING",
                "DISTINCT",
                "OF",
                "VIEW",
                "DOMAIN",
                "ON",
                "WHEN",
                "DOUBLE",
                "ONLY",
                "WHENEVER",
                "DROP",
                "OPEN",
                "WHERE",
                "ELSE",
                "OPTION",
                "WITH",
                "END",
                "OR",
                "WORK",
                "END-EXEC",
                "ORDER",
                "WRITE",
                "ESCAPE",
                "OUTER",
                "YEAR",
                "EXCEPT",
                "OUTPUT",
                "ZONE",
                "EXCEPTION",
                "ABSOLUTE",
                "HOST",
                "RELATIVE",
                "ACTION",
                "HOUR",
                "RELEASE",
                "ADMIN",
                "IGNORE",
                "RESULT",
                "AFTER",
                "IMMEDIATE",
                "RETURNS",
                "AGGREGATE",
                "INDICATOR",
                "ROLE",
                "ALIAS",
                "INITIALIZE",
                "ROLLUP",
                "ALLOCATE",
                "INITIALLY",
                "ROUTINE",
                "ARE",
                "INOUT",
                "ROW",
                "ARRAY",
                "INPUT",
                "ROWS",
                "ASENSITIVE",
                "INT",
                "SAVEPOINT",
                "ASSERTION",
                "INTEGER",
                "SCROLL",
                "ASYMMETRIC",
                "INTERSECTION",
                "SCOPE",
                "AT",
                "INTERVAL",
                "SEARCH",
                "ATOMIC",
                "ISOLATION",
                "SECOND",
                "BEFORE",
                "ITERATE",
                "SECTION",
                "BINARY",
                "LANGUAGE",
                "SENSITIVE",
                "BIT",
                "LARGE",
                "SEQUENCE",
                "BLOB",
                "LAST",
                "SESSION",
                "BOOLEAN",
                "LATERAL",
                "SETS",
                "BOTH",
                "LEADING",
                "SIMILAR",
                "BREADTH",
                "LESS",
                "SIZE",
                "CALL",
                "LEVEL",
                "SMALLINT",
                "CALLED",
                "LIKE_REGEX",
                "SPACE",
                "CARDINALITY",
                "LIMIT",
                "SPECIFIC",
                "CASCADED",
                "LN",
                "SPECIFICTYPE",
                "CAST",
                "LOCAL",
                "SQL",
                "CATALOG",
                "LOCALTIME",
                "SQLEXCEPTION",
                "CHAR",
                "LOCALTIMESTAMP",
                "SQLSTATE",
                "CHARACTER",
                "LOCATOR",
                "SQLWARNING",
                "CLASS",
                "MAP",
                "START",
                "CLOB",
                "MATCH",
                "STATE",
                "COLLATION",
                "MEMBER",
                "STATEMENT",
                "COLLECT",
                "METHOD",
                "STATIC",
                "COMPLETION",
                "MINUTE",
                "STDDEV_POP",
                "CONDITION",
                "MOD",
                "STDDEV_SAMP",
                "CONNECT",
                "MODIFIES",
                "STRUCTURE",
                "CONNECTION",
                "MODIFY",
                "SUBMULTISET",
                "CONSTRAINTS",
                "MODULE",
                "SUBSTRING_REGEX",
                "CONSTRUCTOR",
                "MONTH",
                "SYMMETRIC",
                "CORR",
                "MULTISET",
                "SYSTEM",
                "CORRESPONDING",
                "NAMES",
                "TEMPORARY",
                "COVAR_POP",
                "NATURAL",
                "TERMINATE",
                "COVAR_SAMP",
                "NCHAR",
                "THAN",
                "CUBE",
                "NCLOB",
                "TIME",
                "CUME_DIST",
                "NEW",
                "TIMESTAMP",
                "CURRENT_CATALOG",
                "NEXT",
                "TIMEZONE_HOUR",
                "CURRENT_DEFAULT_TRANSFORM_GROUP",
                "NO",
                "TIMEZONE_MINUTE",
                "CURRENT_PATH",
                "NONE",
                "TRAILING",
                "CURRENT_ROLE",
                "NORMALIZE",
                "TRANSLATE_REGEX",
                "CURRENT_SCHEMA",
                "NUMERIC",
                "TRANSLATION",
                "CURRENT_TRANSFORM_GROUP_FOR_TYPE",
                "OBJECT",
                "TREAT",
                "CYCLE",
                "OCCURRENCES_REGEX",
                "TRUE",
                "DATA",
                "OLD",
                "UESCAPE",
                "DATE",
                "ONLY",
                "UNDER",
                "DAY",
                "OPERATION",
                "UNKNOWN",
                "DEC",
                "ORDINALITY",
                "UNNEST",
                "DECIMAL",
                "OUT",
                "USAGE",
                "DEFERRABLE",
                "OVERLAY",
                "USING",
                "DEFERRED",
                "OUTPUT",
                "VALUE",
                "DEPTH",
                "PAD",
                "VAR_POP",
                "DEREF",
                "PARAMETER",
                "VAR_SAMP",
                "DESCRIBE",
                "PARAMETERS",
                "VARCHAR",
                "DESCRIPTOR",
                "PARTIAL",
                "VARIABLE",
                "DESTROY",
                "PARTITION",
                "WHENEVER",
                "DESTRUCTOR",
                "PATH",
                "WIDTH_BUCKET",
                "DETERMINISTIC",
                "POSTFIX",
                "WITHOUT",
                "DICTIONARY",
                "PREFIX",
                "WINDOW",
                "DIAGNOSTICS",
                "PREORDER",
                "WITHIN",
                "DISCONNECT",
                "PREPARE",
                "WORK",
                "DOMAIN",
                "PERCENT_RANK",
                "WRITE",
                "DYNAMIC",
                "PERCENTILE_CONT",
                "XMLAGG",
                "EACH",
                "PERCENTILE_DISC",
                "XMLATTRIBUTES",
                "ELEMENT",
                "POSITION_REGEX",
                "XMLBINARY",
                "END-EXEC",
                "PRESERVE",
                "XMLCAST",
                "EQUALS",
                "PRIOR",
                "XMLCOMMENT",
                "EVERY",
                "PRIVILEGES",
                "XMLCONCAT",
                "EXCEPTION",
                "RANGE",
                "XMLDOCUMENT",
                "FALSE",
                "READS",
                "XMLELEMENT",
                "FILTER",
                "REAL",
                "XMLEXISTS",
                "FIRST",
                "RECURSIVE",
                "XMLFOREST",
                "FLOAT",
                "REF",
                "XMLITERATE",
                "FOUND",
                "REFERENCING",
                "XMLNAMESPACES",
                "FREE",
                "REGR_AVGX",
                "XMLPARSE",
                "FULLTEXTTABLE",
                "REGR_AVGY",
                "XMLPI",
                "FUSION",
                "REGR_COUNT",
                "XMLQUERY",
                "GENERAL",
                "REGR_INTERCEPT",
                "XMLSERIALIZE",
                "GET",
                "REGR_R2",
                "XMLTABLE",
                "GLOBAL",
                "REGR_SLOPE",
                "XMLTEXT",
                "GO",
                "REGR_SXX",
                "XMLVALIDATE",
                "GROUPING",
                "REGR_SXY",
                "YEAR",
                "HOLD",
                "REGR_SYY"
                 };

        /// <summary>
        /// Special characters to avoid in object names
        /// </summary>
        /// <remarks>
        /// See: https://msdn.microsoft.com/en-us/library/dd172134(v=vs.100).aspx
        /// </remarks>
        private readonly char[] specialCharacters = new char[] { };

        private DesignIssueWarning getDesignIssueForObjectsWithSpecialCharactersInName(Model.Database database)
        {
            DesignIssueWarning warning = new DesignIssueWarning()
            {
                Description = "Database object names should not contain special characters",
                ReferenceUrl = new Uri("https://msdn.microsoft.com/en-us/library/dd172134(v=vs.100).aspx")
            };


            if (database == null)
            {
                return null; //cannot act on empty object
            }

            List<IDbObject> objectList = new List<IDbObject>();

            // check Db name
            if (this.checkForSpecialCharacters(database.ObjectName))
            {
                objectList.Add(database);
            }


            IList<IDbObject> allDbObjList = database.GetAllObjects();

            foreach (IDbObject obj in allDbObjList)
            {
                if (this.checkForSpecialCharacters(obj.ObjectName))
                {
                    objectList.Add(obj);
                }
            }


            //do we have any objects?
            if (objectList.HasAny())
            {
                warning.DatabaseObjects = objectList;
            }
            else
            {
                warning = null;
            }

           
            return warning;
        }

        private bool checkForSpecialCharacters(string input)
        {

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }


            bool containSpecial = false;
            
            //match for: whitepace, double quote, single quote, square brackets
            Regex re = new Regex(@"[\s\""\'\[\]]+", RegexOptions.Compiled);

            Match m = re.Match(input);
            containSpecial = m.Success;

            return containSpecial;
        }



        private DesignIssueWarning getDesignIssueWarningForObjectNamedWithReservedWordssignIssueWarning(Model.Database database)
        {
            DesignIssueWarning warning = new DesignIssueWarning()
            {
                Description = "Database object names should not be reserved words",
                ReferenceUrl = new Uri("https://msdn.microsoft.com/en-us/library/ms189822(SQL.100).aspx")
            };

            if (database == null)
            {
                return null; //cannot act on empty object
            }

            List<IDbObject> objectList = new List<IDbObject>();

            if (this.reservedWords.Contains(database.ObjectName, StringComparer.OrdinalIgnoreCase))
            {
                objectList.Add(database as IDbObject);
            }

            IList<IDbObject> allDbObjList = database.GetAllObjects();


            // union objects to one collection to get one list to parse
            var nameViolations = (
                    from obj in allDbObjList
                    where this.reservedWords.Contains(obj.ObjectName, StringComparer.OrdinalIgnoreCase)
                    orderby obj.ObjectFullDisplayName
                    select obj 
                ).ToList();

            objectList.AddRange(nameViolations);

          
            //do we have any objects?
            if (objectList.HasAny())
            {
                warning.DatabaseObjects = objectList;
            }
            else
            {
                warning = null;
            }
             

            return warning;

        }

        public List<DesignIssueWarning> GetDesignIssueWarnings(Model.Database database)
        {


            if (database == null)
            {
                return null; //cannot act on empty input
            }

            List<DesignIssueWarning> warningList = new List<DesignIssueWarning>();

            DesignIssueWarning objectNamedWithReservedWord = this.getDesignIssueWarningForObjectNamedWithReservedWordssignIssueWarning(database);
            if (objectNamedWithReservedWord != null)
            {
                warningList.Add(objectNamedWithReservedWord);
            }

            DesignIssueWarning objectNameContainingSpecialChars = this.getDesignIssueForObjectsWithSpecialCharactersInName(database);
            if (objectNameContainingSpecialChars != null)
            {
                warningList.Add(objectNameContainingSpecialChars);
            }


            List<DesignIssueWarning> sprocWarningList = this.sprocInspector.GetDesignIssueWarning(database);
            if (sprocWarningList.HasAny())
            {
                warningList.AddRange(sprocWarningList);
            }

            

            return warningList;

        }

    }
}
