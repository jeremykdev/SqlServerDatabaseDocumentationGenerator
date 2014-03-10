using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection
{
    public class ViewInspector : CommonInspector
    {

        public ViewInspector(PetaPoco.Database petaDb):base(petaDb)
        {
          
        }

        public IList<View> GetViews(Schema schema)
        {
            IList<View> viewList = this.getViewsForSchema(schema);


           
            if (viewList != null && viewList.Count > 0)
            {
                var columnInspector = new ColumnInspector(this.peta);

                var indexInspector = new IndexInspector(this.peta);

                for (int v = 0; v < viewList.Count; v++)
                {
                   var view = viewList[v];

                    view.Columns = columnInspector.GetColumns(view);

                    view.Indexes = indexInspector.GetIndexes(view);

                    view.Parent = schema;

                }

            }





            return viewList;
        }


        private IList<View> getViewsForSchema(Schema schema)
        {
            var sql = new Sql(@"SELECT 
                                    V.object_id AS ViewId
	                                , V.[name] AS ViewName
	                                , EP.value AS [Description]

                                FROM sys.views AS V
	                                LEFT OUTER JOIN sys.extended_properties AS EP
		                                ON ( V.object_id = EP.major_id AND EP.class = 1 AND EP.minor_id = 0 AND EP.[name] = 'MS_Description' )

                                WHERE schema_id = @0

                                ORDER BY V.[name];", schema.SchemaId);

            return this.peta.Fetch<View>(sql);
        }
    }
}
