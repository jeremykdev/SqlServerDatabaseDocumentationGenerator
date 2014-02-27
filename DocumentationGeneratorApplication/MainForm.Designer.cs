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
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMainForm)).BeginInit();
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
            this.btnGenerateDoc.Location = new System.Drawing.Point(16, 149);
            this.btnGenerateDoc.Name = "btnGenerateDoc";
            this.btnGenerateDoc.Size = new System.Drawing.Size(150, 23);
            this.btnGenerateDoc.TabIndex = 4;
            this.btnGenerateDoc.Text = "Generate Documentation";
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
            this.btnDocFileBrowse.Location = new System.Drawing.Point(409, 87);
            this.btnDocFileBrowse.Name = "btnDocFileBrowse";
            this.btnDocFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDocFileBrowse.TabIndex = 6;
            this.btnDocFileBrowse.Text = "Browse...";
            this.btnDocFileBrowse.UseVisualStyleBackColor = true;
            this.btnDocFileBrowse.Click += new System.EventHandler(this.btnDocFileBrowse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 198);
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
	}
}

