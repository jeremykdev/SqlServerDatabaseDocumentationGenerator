namespace net.datacowboy.DocumentationGeneratorApplication
{
    partial class FrmObjectsWithoutDescription
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
            this.gvObjects = new System.Windows.Forms.DataGridView();
            this.btnShowSqlScript = new System.Windows.Forms.Button();
            this.lblFormDescription = new System.Windows.Forms.Label();
            this.txtSqlScript = new System.Windows.Forms.TextBox();
            this.lnkCopyToClipboard = new System.Windows.Forms.LinkLabel();
            this.ObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // gvObjects
            // 
            this.gvObjects.AllowUserToAddRows = false;
            this.gvObjects.AllowUserToDeleteRows = false;
            this.gvObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectName,
            this.ObjectType,
            this.Description});
            this.gvObjects.Location = new System.Drawing.Point(12, 35);
            this.gvObjects.Name = "gvObjects";
            this.gvObjects.Size = new System.Drawing.Size(793, 150);
            this.gvObjects.TabIndex = 0;
            // 
            // btnShowSqlScript
            // 
            this.btnShowSqlScript.Location = new System.Drawing.Point(13, 211);
            this.btnShowSqlScript.Name = "btnShowSqlScript";
            this.btnShowSqlScript.Size = new System.Drawing.Size(148, 23);
            this.btnShowSqlScript.TabIndex = 1;
            this.btnShowSqlScript.Text = "Show SQL Scripts";
            this.btnShowSqlScript.UseVisualStyleBackColor = true;
            this.btnShowSqlScript.Click += new System.EventHandler(this.btnShowSqlScript_Click);
            // 
            // lblFormDescription
            // 
            this.lblFormDescription.AutoSize = true;
            this.lblFormDescription.Location = new System.Drawing.Point(13, 13);
            this.lblFormDescription.Name = "lblFormDescription";
            this.lblFormDescription.Size = new System.Drawing.Size(675, 13);
            this.lblFormDescription.TabIndex = 2;
            this.lblFormDescription.Text = "To generate the SQL commands to add descriptions to database objects fill in the " +
    "Description column then click the Show SQL Scripts button.";
            // 
            // txtSqlScript
            // 
            this.txtSqlScript.Location = new System.Drawing.Point(12, 259);
            this.txtSqlScript.Multiline = true;
            this.txtSqlScript.Name = "txtSqlScript";
            this.txtSqlScript.ReadOnly = true;
            this.txtSqlScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSqlScript.Size = new System.Drawing.Size(884, 90);
            this.txtSqlScript.TabIndex = 3;
            // 
            // lnkCopyToClipboard
            // 
            this.lnkCopyToClipboard.AutoSize = true;
            this.lnkCopyToClipboard.Location = new System.Drawing.Point(16, 356);
            this.lnkCopyToClipboard.Name = "lnkCopyToClipboard";
            this.lnkCopyToClipboard.Size = new System.Drawing.Size(90, 13);
            this.lnkCopyToClipboard.TabIndex = 4;
            this.lnkCopyToClipboard.TabStop = true;
            this.lnkCopyToClipboard.Text = "Copy to Clipboard";
            this.lnkCopyToClipboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCopyToClipboard_LinkClicked);
            // 
            // ObjectName
            // 
            this.ObjectName.DataPropertyName = "ObjectFullDisplayName";
            this.ObjectName.HeaderText = "Object Name";
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.ReadOnly = true;
            this.ObjectName.Width = 150;
            // 
            // ObjectType
            // 
            this.ObjectType.DataPropertyName = "ObjectTypeDisplayText";
            this.ObjectType.HeaderText = "Object Type";
            this.ObjectType.Name = "ObjectType";
            this.ObjectType.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 500;
            // 
            // FrmObjectsWithoutDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 378);
            this.Controls.Add(this.lnkCopyToClipboard);
            this.Controls.Add(this.txtSqlScript);
            this.Controls.Add(this.lblFormDescription);
            this.Controls.Add(this.btnShowSqlScript);
            this.Controls.Add(this.gvObjects);
            this.Name = "FrmObjectsWithoutDescription";
            this.Text = "Objects Without a Description";
            this.Load += new System.EventHandler(this.FrmObjectsWithoutDescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvObjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvObjects;
        private System.Windows.Forms.Button btnShowSqlScript;
        private System.Windows.Forms.Label lblFormDescription;
        private System.Windows.Forms.TextBox txtSqlScript;
        private System.Windows.Forms.LinkLabel lnkCopyToClipboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}