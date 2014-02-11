using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using PetaPoco;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
	public class IndexInspector
	{
		private PetaPoco.Database peta;

		public IndexInspector(PetaPoco.Database petaDb)
		{
			this.peta = petaDb;
		}

		public IList<Index> GetIndexes(IDbObject parent)
		{
			IList<Index> indexList = null;

			if (parent is Table)
			{
				indexList = this.getTableIndexes(parent as Table);
			}

			//TODO: support views



			//TODO: lookup columns

			return indexList;
		}


		private IList<Index> getTableIndexes(Table table)
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

							ORDER BY I.[name];", table.TableId);

			return this.peta.Fetch<Index>(sql);
		}


	}
}
