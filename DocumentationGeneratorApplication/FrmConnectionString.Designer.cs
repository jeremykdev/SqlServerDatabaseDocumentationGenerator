namespace net.datacowboy.DocumentationGeneratorApplication
{
    partial class FrmConnectionString
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
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.gbAuthentication = new System.Windows.Forms.GroupBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.rdoSql = new System.Windows.Forms.RadioButton();
            this.rdoIntegrated = new System.Windows.Forms.RadioButton();
            this.frmErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbAuthentication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(13, 13);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(107, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Data Source (Server)";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(143, 10);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(214, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Validating += new System.ComponentModel.CancelEventHandler(this.txtServer_Validating);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(13, 46);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(125, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Initial Catalog (Database)";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(141, 46);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(214, 20);
            this.txtDatabase.TabIndex = 3;
            this.txtDatabase.Validating += new System.ComponentModel.CancelEventHandler(this.txtDatabase_Validating);
            // 
            // gbAuthentication
            // 
            this.gbAuthentication.Controls.Add(this.chkShowPassword);
            this.gbAuthentication.Controls.Add(this.txtPassword);
            this.gbAuthentication.Controls.Add(this.txtUserName);
            this.gbAuthentication.Controls.Add(this.lblPassword);
            this.gbAuthentication.Controls.Add(this.lblUserName);
            this.gbAuthentication.Controls.Add(this.rdoSql);
            this.gbAuthentication.Controls.Add(this.rdoIntegrated);
            this.gbAuthentication.Location = new System.Drawing.Point(16, 73);
            this.gbAuthentication.Name = "gbAuthentication";
            this.gbAuthentication.Size = new System.Drawing.Size(288, 141);
            this.gbAuthentication.TabIndex = 4;
            this.gbAuthentication.TabStop = false;
            this.gbAuthentication.Text = "Authentication";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(22, 118);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(101, 17);
            this.chkShowPassword.TabIndex = 6;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(74, 66);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 68);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User name";
            // 
            // rdoSql
            // 
            this.rdoSql.AutoSize = true;
            this.rdoSql.Location = new System.Drawing.Point(7, 44);
            this.rdoSql.Name = "rdoSql";
            this.rdoSql.Size = new System.Drawing.Size(46, 17);
            this.rdoSql.TabIndex = 1;
            this.rdoSql.TabStop = true;
            this.rdoSql.Text = "SQL";
            this.rdoSql.UseVisualStyleBackColor = true;
            this.rdoSql.CheckedChanged += new System.EventHandler(this.rdoSql_CheckedChanged);
            // 
            // rdoIntegrated
            // 
            this.rdoIntegrated.AutoSize = true;
            this.rdoIntegrated.Location = new System.Drawing.Point(7, 20);
            this.rdoIntegrated.Name = "rdoIntegrated";
            this.rdoIntegrated.Size = new System.Drawing.Size(114, 17);
            this.rdoIntegrated.TabIndex = 0;
            this.rdoIntegrated.TabStop = true;
            this.rdoIntegrated.Text = "Integrated Security";
            this.rdoIntegrated.UseVisualStyleBackColor = true;
            this.rdoIntegrated.CheckedChanged += new System.EventHandler(this.rdoIntegrated_CheckedChanged);
            // 
            // frmErrorProvider
            // 
            this.frmErrorProvider.ContainerControl = this;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(16, 220);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(111, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(179, 257);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(258, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gbAuthentication);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnectionString";
            this.Text = "Connection String";
            this.Load += new System.EventHandler(this.FrmConnectionString_Load);
            this.gbAuthentication.ResumeLayout(false);
            this.gbAuthentication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.GroupBox gbAuthentication;
        private System.Windows.Forms.RadioButton rdoIntegrated;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.RadioButton rdoSql;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.ErrorProvider frmErrorProvider;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}