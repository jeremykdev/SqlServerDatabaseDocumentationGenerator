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
using Be.Timvw.Framework.ComponentModel;
using Be.Timvw.Framework.Collections.Generic;

namespace net.datacowboy.DocumentationGeneratorApplication
{
    public partial class FrmObjectsWithoutDescription : Form
    {
        private net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database;

        private SortableBindingList<IDbObject> boundList;

        public FrmObjectsWithoutDescription(net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database)
        {
            InitializeComponent();

            this.database = database;
        }

        private void FrmObjectsWithoutDescription_Load(object sender, EventArgs e)
        {
            this.boundList = new SortableBindingList<IDbObject>(this.database.FindObjectsWithoutDescriptionInDatabase());

            
            this.gvObjects.AutoGenerateColumns = false;
            this.gvObjects.DataSource = this.boundList;

            this.lnkCopyToClipboard.Visible = false;
       }

        private void btnShowSqlScript_Click(object sender, EventArgs e)
        {
            this.txtSqlScript.Clear();
            this.lnkCopyToClipboard.Visible = false;


            if (this.boundList.HasAny())
            {
                //filter for edits 
                var updatedList = this.boundList.Where(i => !String.IsNullOrWhiteSpace(i.Description)).ToArray();

              
                if (updatedList.HasAny())
                {
                    var sb = new StringBuilder();

                    sb.Append("USE [");
                    sb.Append(this.database.DatabaseName);
                    sb.Append("];");
                    


                    for(int i=0; i<updatedList.Count(); i++)
                    {
                        sb.Append("\r\n\r\n");
                        sb.Append(updatedList[i].CreateIDbObjectDescriptionSqlCommandText());
                    }

                    this.txtSqlScript.Text = sb.ToString();
                    this.lnkCopyToClipboard.Visible = true;
                }
            }

           
        }

        private void lnkCopyToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtSqlScript.Text))
            {
                Clipboard.SetText(this.txtSqlScript.Text);
            }
        }
    }
}
