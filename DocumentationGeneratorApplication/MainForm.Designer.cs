namespace net.datacowboy.DocumentationGeneratorApplication
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblDocFile = new System.Windows.Forms.Label();
            this.txtDocFile = new System.Windows.Forms.TextBox();
            this.btnGenerateDoc = new System.Windows.Forms.Button();
            this.chkOpenDoc = new System.Windows.Forms.CheckBox();
            this.errorProviderMainForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDocFileBrowse = new System.Windows.Forms.Button();
            this.btnEditConnection = new System.Windows.Forms.Button();
            this.btnFindObjectsWithoutDescription = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.chkCheckForDatabaseDesignIssues = new System.Windows.Forms.CheckBox();
            this.chkFkToTableHyperLink = new System.Windows.Forms.CheckBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMainForm)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(13, 13);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(91, 13);
            this.lblConnectionString.TabIndex = 0;
            this.lblConnectionString.Text = "Connection String";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(12, 29);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(471, 20);
            this.txtConnectionString.TabIndex = 1;
            // 
            // lblDocFile
            // 
            this.lblDocFile.AutoSize = true;
            this.lblDocFile.Location = new System.Drawing.Point(12, 70);
            this.lblDocFile.Name = "lblDocFile";
            this.lblDocFile.Size = new System.Drawing.Size(98, 13);
            this.lblDocFile.TabIndex = 2;
            this.lblDocFile.Text = "Documentation File";
            // 
            // txtDocFile
            // 
            this.txtDocFile.Location = new System.Drawing.Point(15, 87);
            this.txtDocFile.Name = "txtDocFile";
            this.txtDocFile.Size = new System.Drawing.Size(387, 20);
            this.txtDocFile.TabIndex = 3;
            // 
            // btnGenerateDoc
            // 
            this.btnGenerateDoc.Location = new System.Drawing.Point(12, 209);
            this.btnGenerateDoc.Name = "btnGenerateDoc";
            this.btnGenerateDoc.Size = new System.Drawing.Size(150, 23);
            this.btnGenerateDoc.TabIndex = 8;
            this.btnGenerateDoc.Text = "Generate Documentation";
            this.ttMain.SetToolTip(this.btnGenerateDoc, "Generate documentation file");
            this.btnGenerateDoc.UseVisualStyleBackColor = true;
            this.btnGenerateDoc.Click += new System.EventHandler(this.btnGenerateDoc_Click);
            // 
            // chkOpenDoc
            // 
            this.chkOpenDoc.AutoSize = true;
            this.chkOpenDoc.Checked = true;
            this.chkOpenDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenDoc.Location = new System.Drawing.Point(16, 114);
            this.chkOpenDoc.Name = "chkOpenDoc";
            this.chkOpenDoc.Size = new System.Drawing.Size(178, 17);
            this.chkOpenDoc.TabIndex = 5;
            this.chkOpenDoc.Text = "Open Document When Finished";
            this.chkOpenDoc.UseVisualStyleBackColor = true;
            // 
            // errorProviderMainForm
            // 
            this.errorProviderMainForm.ContainerControl = this;
            // 
            // btnDocFileBrowse
            // 
            this.btnDocFileBrowse.Location = new System.Drawing.Point(421, 87);
            this.btnDocFileBrowse.Name = "btnDocFileBrowse";
            this.btnDocFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDocFileBrowse.TabIndex = 4;
            this.btnDocFileBrowse.Text = "Browse...";
            this.ttMain.SetToolTip(this.btnDocFileBrowse, "Browse for documentation file location");
            this.btnDocFileBrowse.UseVisualStyleBackColor = true;
            this.btnDocFileBrowse.Click += new System.EventHandler(this.btnDocFileBrowse_Click);
            // 
            // btnEditConnection
            // 
            this.btnEditConnection.Location = new System.Drawing.Point(497, 26);
            this.btnEditConnection.Name = "btnEditConnection";
            this.btnEditConnection.Size = new System.Drawing.Size(75, 23);
            this.btnEditConnection.TabIndex = 2;
            this.btnEditConnection.Text = "Edit...";
            this.ttMain.SetToolTip(this.btnEditConnection, "Edit connection string");
            this.btnEditConnection.UseVisualStyleBackColor = true;
            this.btnEditConnection.Click += new System.EventHandler(this.btnEditConnection_Click);
            // 
            // btnFindObjectsWithoutDescription
            // 
            this.btnFindObjectsWithoutDescription.Location = new System.Drawing.Point(187, 209);
            this.btnFindObjectsWithoutDescription.Name = "btnFindObjectsWithoutDescription";
            this.btnFindObjectsWithoutDescription.Size = new System.Drawing.Size(192, 23);
            this.btnFindObjectsWithoutDescription.TabIndex = 9;
            this.btnFindObjectsWithoutDescription.Text = "Find Objects Without a Description";
            this.ttMain.SetToolTip(this.btnFindObjectsWithoutDescription, "Find database objects without a description");
            this.btnFindObjectsWithoutDescription.UseVisualStyleBackColor = true;
            this.btnFindObjectsWithoutDescription.Click += new System.EventHandler(this.btnFindObjectsWithoutDescription_Click);
            // 
            // chkCheckForDatabaseDesignIssues
            // 
            this.chkCheckForDatabaseDesignIssues.AutoSize = true;
            this.chkCheckForDatabaseDesignIssues.Location = new System.Drawing.Point(16, 162);
            this.chkCheckForDatabaseDesignIssues.Name = "chkCheckForDatabaseDesignIssues";
            this.chkCheckForDatabaseDesignIssues.Size = new System.Drawing.Size(190, 17);
            this.chkCheckForDatabaseDesignIssues.TabIndex = 7;
            this.chkCheckForDatabaseDesignIssues.Text = "Check for Database Design Issues";
            this.ttMain.SetToolTip(this.chkCheckForDatabaseDesignIssues, "Check for possible database design issues");
            this.chkCheckForDatabaseDesignIssues.UseVisualStyleBackColor = true;
            // 
            // chkFkToTableHyperLink
            // 
            this.chkFkToTableHyperLink.AutoSize = true;
            this.chkFkToTableHyperLink.Checked = true;
            this.chkFkToTableHyperLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFkToTableHyperLink.Location = new System.Drawing.Point(15, 138);
            this.chkFkToTableHyperLink.Name = "chkFkToTableHyperLink";
            this.chkFkToTableHyperLink.Size = new System.Drawing.Size(286, 17);
            this.chkFkToTableHyperLink.TabIndex = 6;
            this.chkFkToTableHyperLink.Text = "Generate Foreign Key to Table Hyperlinks in Document";
            this.chkFkToTableHyperLink.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStripMain.Location = new System.Drawing.Point(0, 301);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(635, 22);
            this.statusStripMain.TabIndex = 11;
            this.statusStripMain.Text = "fd";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 323);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.chkCheckForDatabaseDesignIssues);
            this.Controls.Add(this.chkFkToTableHyperLink);
            this.Controls.Add(this.btnFindObjectsWithoutDescription);
            this.Controls.Add(this.btnEditConnection);
            this.Controls.Add(this.btnDocFileBrowse);
            this.Controls.Add(this.chkOpenDoc);
            this.Controls.Add(this.btnGenerateDoc);
            this.Controls.Add(this.txtDocFile);
            this.Controls.Add(this.lblDocFile);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.lblConnectionString);
            this.Name = "MainForm";
            this.Text = "SQL Server Database Documentation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMainForm)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblConnectionString;
		private System.Windows.Forms.TextBox txtConnectionString;
		private System.Windows.Forms.Label lblDocFile;
		private System.Windows.Forms.TextBox txtDocFile;
		private System.Windows.Forms.Button btnGenerateDoc;
		private System.Windows.Forms.CheckBox chkOpenDoc;
        private System.Windows.Forms.ErrorProvider errorProviderMainForm;
        private System.Windows.Forms.Button btnDocFileBrowse;
        private System.Windows.Forms.Button btnEditConnection;
        private System.Windows.Forms.Button btnFindObjectsWithoutDescription;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.CheckBox chkFkToTableHyperLink;
        private System.Windows.Forms.CheckBox chkCheckForDatabaseDesignIssues;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

