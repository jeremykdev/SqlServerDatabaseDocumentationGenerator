using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.DocumentationGeneratorApplication
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//provide defaults

			this.txtConnectionString.Text = @"Data Source=localhost\sqlexpress; Initial Catalog=AdventureWorks; Integrated Security=true;";

			this.txtDocFile.Text = "documentation.html";


		}

        private void clearErrorMessages()
        {
            this.errorProviderMainForm.Clear();
        }

        private bool validateFormInput()
        {

            bool errorFound = false;

            this.clearErrorMessages();

            //was a connection string provided?
            if (String.IsNullOrWhiteSpace(this.txtConnectionString.Text))
            {
                errorFound = true;
                this.errorProviderMainForm.SetError(this.txtConnectionString, "Please provide a connection string");
            }
            else
            {
                var connectionTestResult = SqlConnectionTester.TestConnectionString(this.txtConnectionString.Text, true);
                if (!connectionTestResult.Success)
                {
                    errorFound = true;
                    this.errorProviderMainForm.SetError(this.txtConnectionString, (connectionTestResult.ErrorMessage ?? "Invalid connection string"));
                }

            }

            //has an ouptut filename with optional path been provided?
            if (String.IsNullOrWhiteSpace(this.txtDocFile.Text))
            {
                errorFound = true;
                this.errorProviderMainForm.SetError(this.txtDocFile, "Please enter a filename for the documentation file to be created");
            }
            else
            {
                string proposedFilename = this.txtDocFile.Text.Trim();

                FileInfo fileInfo = null;

                try
                {
                    fileInfo = new FileInfo(proposedFilename);
                }
                catch
                {
                    errorFound = true;
                    this.errorProviderMainForm.SetError(this.txtDocFile, "Proposed filename is invalid");
                }


                //is an HTML file extension
                if(fileInfo != null && !( fileInfo.Extension.ToLower() == ".htm" || fileInfo.Extension.ToLower() == ".html"))
                {
                    errorFound = true;
                    this.errorProviderMainForm.SetError(this.txtDocFile, "File name must have .htm or .html file extension");
                }


            }
            

            return !errorFound; //input valid when no errors found

        }


		private void btnGenerateDoc_Click(object sender, EventArgs e)
		{
            if (!this.validateFormInput())
            {
                return;
            }

            this.btnGenerateDoc.Enabled = false;
            

			var dbi = new DatabaseInspector(this.txtConnectionString.Text);
			var metadata = dbi.GetDatabaseMetaData();

			DatabaseHtmlDocumentGenerator gen = new DatabaseHtmlDocumentGenerator();

			string docFilePath = this.txtDocFile.Text.Trim();

			using (var sw = new StreamWriter(docFilePath, false))
			{
				var str = gen.ExportToHtml(metadata, sw);
			}

			if (this.chkOpenDoc.Checked && File.Exists(docFilePath))
			{
				Process.Start(docFilePath);
			}

            this.btnGenerateDoc.Enabled = true;
		}
	}
}
