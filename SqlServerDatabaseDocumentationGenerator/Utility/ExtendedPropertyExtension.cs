using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{
    /// <summary>
    /// Collection of extenision methods to generate SQL scripts for extended properties
    /// </summary>
    public static class ExtendedPropertyExtension
    {
        private static string createAddExtendedPropertySprocTextForMsDescription(string description, string level0type=null, string level0name=null, string level1type = null, string level1name = null, string level2type = null, string level2name = null)
        {
            var sb = new StringBuilder("EXEC sp_addextendedproperty @name='MS_Description'");
            sb.Append(" , @value=");
            sb.Append(description.ToSqlQuotedText());

            if (!String.IsNullOrWhiteSpace(level0name) && !String.IsNullOrWhiteSpace(level0type))
            {
                sb.Append(" , @level0type=");
                sb.Append(level0type.ToSqlQuotedText());
                sb.Append(" , @level0name=");
                sb.Append(level0name.ToSqlQuotedText());
            }
            

            if (!String.IsNullOrWhiteSpace(level1name) && !String.IsNullOrWhiteSpace(level1type))
            {
                sb.Append(" , @level1type=");
                sb.Append(level1type.ToSqlQuotedText());
                sb.Append(" , @level1name=");
                sb.Append(level1name.ToSqlQuotedText());
            }

            if (!String.IsNullOrWhiteSpace(level2name) && !String.IsNullOrWhiteSpace(level2type))
            {
                sb.Append(" , @level2type=");
                sb.Append(level2type.ToSqlQuotedText());
                sb.Append(" , @level2name=");
                sb.Append(level2name.ToSqlQuotedText());
            }

            sb.Append(";");

            return sb.ToString();
        }

        public static string CreateIDbObjectDescriptionSqlCommandText(this IDbObject obj)
        {
            if (obj is Database)
            {
                return (obj as Database).CreateDescriptionSqlCommandText();
            }

            if (obj is Schema)
            {
                return (obj as Schema).CreateDescriptionSqlCommandText();
            }

            if (obj is Table)
            {
                return (obj as Table).CreateDescriptionSqlCommandText();
            }

            if (obj is View)
            {
                return (obj as View).CreateDescriptionSqlCommandText();
            }

            if (obj is StoredProcedure)
            {
                return (obj as StoredProcedure).CreateDescriptionSqlCommandText();
            }

            

            //TODO: support additional types

            return String.Empty;
        }

        public static string CreateDescriptionSqlCommandText(this Database db)
        {
            return createAddExtendedPropertySprocTextForMsDescription(db.Description);
        }

        public static string CreateDescriptionSqlCommandText(this View view)
        {
            return createAddExtendedPropertySprocTextForMsDescription(view.Description, "SCHEMA", view.Parent.ObjectName, "VIEW", view.ViewName);
        }


        public static string CreateDescriptionSqlCommandText(this Schema schema)
        {
            return createAddExtendedPropertySprocTextForMsDescription(schema.Description, "SCHEMA", schema.SchemaName);
        }

        public static string CreateDescriptionSqlCommandText(this Table table)
        {
            return createAddExtendedPropertySprocTextForMsDescription(table.Description, "SCHEMA", table.Parent.ObjectName, "TABLE", table.TableName);
        }

        public static string CreateDescriptionSqlCommandText(this StoredProcedure sproc)
        {
            return createAddExtendedPropertySprocTextForMsDescription(sproc.Description, "SCHEMA", sproc.Parent.ObjectName, "PROCEDURE", sproc.ObjectName);
        }

    }
}
