using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ForeignKeyInspector
    {
        private PetaPoco.Database peta;

        public ForeignKeyInspector(PetaPoco.Database petaDb)
		{
			this.peta = petaDb;		
		
		}

        public IList<ForeignKey> GetForeignKeys(Table table)
        {
            IList<ForeignKey> fkList = this.queryForForeignKeys(table);



            //TODO: add columns

            return fkList;
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
