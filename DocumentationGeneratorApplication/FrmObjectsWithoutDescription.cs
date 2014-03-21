using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.DocumentationGeneratorApplication
{
    public partial class FrmObjectsWithoutDescription : Form
    {
        private net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database;

        private BindingList<IDbObject> boundList;

        public FrmObjectsWithoutDescription(net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database)
        {
            InitializeComponent();

            this.database = database;
        }

        private void FrmObjectsWithoutDescription_Load(object sender, EventArgs e)
        {
            this.boundList = new BindingList<IDbObject>(this.database.FindObjectsWithoutDescriptionInDatabase());

            
            this.gvObjects.AutoGenerateColumns = false;
            this.gvObjects.DataSource = this.boundList;
          


        }

        private void btnShowSqlScript_Click(object sender, EventArgs e)
        {
            this.txtSqlScript.Clear();

            MessageBox.Show("This feature not yet completed");

            if (this.boundList.HasAny())
            {
                //filter for edits 
                var updatedList = this.boundList.Where(i => !String.IsNullOrWhiteSpace(i.Description)).ToArray();

              
                if (updatedList.HasAny())
                {
                    var sb = new StringBuilder();

                    sb.Append("USE ");
                    sb.Append(this.database.DatabaseName);
                    sb.Append(";");
                    


                    for(int i=0; i<updatedList.Count(); i++)
                    {
                        sb.Append("\r\n\r\n");
                        sb.Append(updatedList[i].CreateIDbObjectDescriptionSqlCommandText());
                    }

                    this.txtSqlScript.Text = sb.ToString();
                }
            }

           
        }
    }
}
