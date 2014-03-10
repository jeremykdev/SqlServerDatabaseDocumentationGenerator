using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ForeignKeyInspector : CommonInspector
    {
        
        public ForeignKeyInspector(PetaPoco.Database petaDb):base(petaDb)
		{
			
		}

        public IList<ForeignKey> GetForeignKeys(Table table)
        {
            IList<ForeignKey> fkList = this.queryForForeignKeys(table);

            if (fkList != null && fkList.Count > 0)
            {
                for (int k = 0; k < fkList.Count; k++)
                {
                    var fk = fkList[k];

                    fk.ForeignKeyColumns = this.queryForForeignKeyColumns(table, fk);
                    fk.Parent = table;
                }

                
            }


            return fkList;
        }

        private IList<ForeignKeyColumn> queryForForeignKeyColumns(Table table, ForeignKey fk)
        {
            var sql = new Sql(@"SELECT 
	                                FKC.parent_column_id AS  ParentColumnId
	                                , PC.[name] AS ParentColumnName
	                                , FKC.referenced_column_id AS ReferenceColumnId
	                                , RC.[name] AS ReferenceColumnName
                                    , FKC.constraint_column_id AS ConstraintColumnId

                                FROM sys.foreign_key_columns AS FKC
	                                INNER JOIN sys.columns AS PC
		                                ON ( FKC.parent_object_id = PC.object_id AND FKC.parent_column_id = PC.column_id )
	                                INNER JOIN sys.columns AS RC
		                                ON ( FKC.referenced_object_id = RC.object_id AND FKC.referenced_column_id = RC.column_id )

                                WHERE FKC.parent_object_id = @0
	                                AND FKC.constraint_object_id = @1
	
                                ORDER BY FKC.constraint_column_id;", table.TableId, fk.ForeignKeyId);

            return this.peta.Fetch<ForeignKeyColumn>(sql);
        }

        private IList<ForeignKey> queryForForeignKeys(Table table)
        {
            var sql = new Sql(@"SELECT 
	            FK.[name] AS ForeignKeyName
	            , FK.object_id AS ForeignKeyId
	            , FK.referenced_object_id AS ReferencedObjectId
	            , REF.[name] AS ReferencedObjectName
	            , RS.[name] AS ReferencedObjectSchemaName
	            , FK.delete_referential_action_desc AS DeleteReferentialAction
	            , FK.update_referential_action_desc AS UpdateReferentialAction
	            , FK.is_disabled AS IsDisabled
	            , FK.is_not_trusted AS IsNotTrusted
                , EP.value AS [Description]

            FROM sys.foreign_keys AS FK
	            INNER JOIN sys.objects AS REF
		            ON ( FK.referenced_object_id = REF.object_id )
	            INNER JOIN sys.schemas AS RS
		            ON ( REF.schema_id = RS.schema_id )
                LEFT OUTER JOIN sys.extended_properties AS EP
		            ON ( EP.class = 1 AND EP.name = 'MS_Description' AND EP.major_id = FK.object_id AND EP.minor_id = 0 )

            WHERE FK.parent_object_id = @0

            ORDER BY FK.[name];", table.TableId);

            return this.peta.Fetch<ForeignKey>(sql);
        }

    }
}
