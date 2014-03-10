using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class IndexInspector : CommonInspector
	{
		

		public IndexInspector(PetaPoco.Database petaDb):base(petaDb)
		{
			
		}

		public IList<Index> GetIndexes(IDbObject parent)
		{
			IList<Index> indexList = null;

			indexList = this.getTableOrViewIndexes(parent);
		
   			//lookup columns
            if (indexList != null && indexList.Count > 0)
            {
                for (int i = 0; i < indexList.Count; i++)
                {
                    indexList[i].ColumnNames = this.getIndexColumnNames(indexList[i], parent);
                    indexList[i].Parent = parent;
                }

            }

			return indexList;
		}

        private IList<string> getIndexColumnNames(Index index, IDbObject parent)
        {
            var sql = new Sql(@"SELECT C.[name]

                            FROM sys.indexes AS I  
 	                            INNER JOIN sys.index_columns AS IC  	
		                            ON ( I.index_id = IC.index_id AND I.object_id = IC.object_id )
	                            INNER JOIN sys.columns AS C
		                            ON ( C.object_id = IC.object_id AND C.column_id = IC.column_id )

                            WHERE I.object_id = @0
	                            AND I.index_id = @1
	
                            ORDER BY IC.key_ordinal, C.[name];", parent.ObjectId, index.IndexId);

            return this.peta.Fetch<string>(sql); 

        }


		private IList<Index> getTableOrViewIndexes(IDbObject parent)
		{
	
			var sql = new Sql(@"SELECT I.[name] AS IndexName
								, I.index_id AS IndexId
								, EP.value AS [Description]
								, I.is_unique AS IsUnique
								, I.is_primary_key AS IsPrimaryKey
								, I.type_desc AS IndexTypeDescription

							FROM sys.indexes AS I
								LEFT OUTER JOIN sys.extended_properties AS EP
									ON ( EP.class = 7 AND EP.name = 'MS_Description' AND EP.major_id = I.object_id AND EP.minor_id = I.index_id )

							WHERE object_id = @0
								AND I.index_id != 0

							ORDER BY I.[name];", parent.ObjectId);

			return this.peta.Fetch<Index>(sql);
		}


	}
}
