using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.DocumentationGeneratorApplication
{
    public partial class FrmObjectsWithoutDescription : Form
    {
        private net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database;

        public FrmObjectsWithoutDescription(net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model.Database database)
        {
            InitializeComponent();

            this.database = database;
        }

        private void FrmObjectsWithoutDescription_Load(object sender, EventArgs e)
        {
            var itemsWithoutDescription = this.database.FindObjectsWithoutDescriptionInDatabase();

            if (itemsWithoutDescription.HasAny())
            {
                this.gvObjects.AutoGenerateColumns = false;
                this.gvObjects.DataSource = itemsWithoutDescription;
            }


        }
    }
}
