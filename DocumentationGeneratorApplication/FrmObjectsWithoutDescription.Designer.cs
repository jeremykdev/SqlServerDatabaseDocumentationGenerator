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
            this.ObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // gvObjects
            // 
            this.gvObjects.AllowUserToAddRows = false;
            this.gvObjects.AllowUserToDeleteRows = false;
            this.gvObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectName});
            this.gvObjects.Location = new System.Drawing.Point(13, 22);
            this.gvObjects.Name = "gvObjects";
            this.gvObjects.ReadOnly = true;
            this.gvObjects.Size = new System.Drawing.Size(352, 150);
            this.gvObjects.TabIndex = 0;
            // 
            // ObjectName
            // 
            this.ObjectName.DataPropertyName = "ObjectName";
            this.ObjectName.HeaderText = "Object Name";
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.ReadOnly = true;
            this.ObjectName.Width = 250;
            // 
            // FrmObjectsWithoutDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 262);
            this.Controls.Add(this.gvObjects);
            this.Name = "FrmObjectsWithoutDescription";
            this.Text = "Objects Without a Description";
            this.Load += new System.EventHandler(this.FrmObjectsWithoutDescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvObjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvObjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectName;
    }
}