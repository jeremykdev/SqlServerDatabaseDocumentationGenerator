using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Inspection;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document;

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

			//Server=.; Database=AdventureWorks; Integrated Security=true;

			this.txtConnectionString.Text = @"Data Source=localhost; Initial Catalog=AdventureWorks; Integrated Security=true;";

			this.txtDocFile.Text = "documentation.html";


		}

		private void btnGenerateDoc_Click(object sender, EventArgs e)
		{
			//TODO: validate input

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
		}
	}
}
