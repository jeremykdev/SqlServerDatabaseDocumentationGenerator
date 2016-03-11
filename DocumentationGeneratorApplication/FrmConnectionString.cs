using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility;

namespace net.datacowboy.DocumentationGeneratorApplication
{
    public partial class FrmConnectionString : Form
    {


        /// <summary>
        /// Dialog result for form
        /// </summary>
        public DialogResult Result = DialogResult.Cancel;

        /// <summary>
        /// Create SQL server connection string based on inputs in UI
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
           
            try
            {
                var builder = new SqlConnectionStringBuilder();

                if (!String.IsNullOrEmpty(this.txtServer.Text))
                {
                    builder.DataSource = this.txtServer.Text.Trim();
                }

                if (!String.IsNullOrWhiteSpace(this.txtDatabase.Text))
                {
                    builder.InitialCatalog = this.txtDatabase.Text.Trim();
                }

                //assume integrated security unless SQL checked
                builder.IntegratedSecurity = !this.rdoSql.Checked;
                if (this.rdoSql.Checked)
                {
                    if (!String.IsNullOrWhiteSpace(this.txtUserName.Text))
                    {
                        builder.UserID = this.txtUserName.Text;
                    }

                    //allow empty password, don't check for length
                    builder.Password = this.txtPassword.Text ?? String.Empty;
                }

                return builder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Unable to create connection string:\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
        }

        //Inetgrated secuirty mode selected
        private void integratedSecurityModeSetup()
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.txtUserName.Enabled = false;
            this.txtPassword.Enabled = false;
            this.chkShowPassword.Enabled = false;
            this.frmErrorProvider.SetError(this.rdoIntegrated, String.Empty);
        }

        //SQL auth security mode selected
        private void sqlAuthModeSetup()
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.txtUserName.Enabled = true;
            this.txtPassword.Enabled = true;
            this.chkShowPassword.Enabled = true;
            this.frmErrorProvider.SetError(this.rdoIntegrated, String.Empty);
        }

       

        public FrmConnectionString(string connectionString="")
        {
            InitializeComponent();

            SqlConnectionStringBuilder builder = null;

            if (!String.IsNullOrWhiteSpace(connectionString))
            {

                try
                {


                    builder = new SqlConnectionStringBuilder(connectionString);
                }
                catch (Exception ex)
                {
                    //TODO: tell user something wrong in initial connection string
                }

                if (!String.IsNullOrWhiteSpace(builder.DataSource))
                {
                    this.txtServer.Text = builder.DataSource;
                }

                if (!String.IsNullOrWhiteSpace(builder.InitialCatalog))
                {
                    this.txtDatabase.Text = builder.InitialCatalog;
                }

                if (builder.IntegratedSecurity)
                {
                    this.rdoIntegrated.Checked = true;
                    this.integratedSecurityModeSetup();
                }
                else
                {
                    this.rdoSql.Checked = true;
                    this.sqlAuthModeSetup();

                    if (!String.IsNullOrWhiteSpace(builder.UserID))
                    {
                        this.txtUserName.Text = builder.UserID;
                    }

                    if (!String.IsNullOrWhiteSpace(builder.Password))
                    {
                        this.txtPassword.Text = builder.Password;
                    }
                }



            }

        }

        private void FrmConnectionString_Load(object sender, EventArgs e)
        {

        }

        private void rdoIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoIntegrated.Checked)
            {
                this.integratedSecurityModeSetup();
            }
        }

        private void rdoSql_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSql.Checked)
            {
                this.sqlAuthModeSetup();
            }
        }

        //control if password characters shown or hidden
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkShowPassword.Checked)
            {
                this.txtPassword.PasswordChar = '\0'; 
            }
            else
            {
                this.txtPassword.PasswordChar = '*';
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.enableOrDisableUi(false);

            if (this.validateUiInput())
            {
                this.testConnectionString();
            }

            this.enableOrDisableUi(true);
        }

        /// <summary>
        /// Enable or disable UI controls
        /// </summary>
        /// <param name="enable">True to enable, false to disable</param>
        private void enableOrDisableUi(bool enable)
        {
            this.Enabled = enable;
        }
        

        private void testConnectionString()
        {
            string connStr = this.GetConnectionString();


            var testResult = SqlConnectionTester.TestConnectionString(connStr);

            if (testResult.Success)
            {
                MessageBox.Show("Connection test successful", "Connection Test Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show(String.Format("Connection test failed.\n{0}", testResult.ErrorMessage), "Connection Test Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if UI valid close form
            if (this.validateUiInput())
            {
                this.Result = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private bool validateUiInput()
        {
            this.frmErrorProvider.Clear();

            bool errorFound = false;

            if (String.IsNullOrWhiteSpace(this.txtServer.Text))
            {
                errorFound = true;
                this.frmErrorProvider.SetError(this.txtServer, "Server cannot be empty");
            }

            if (String.IsNullOrWhiteSpace(this.txtDatabase.Text))
            {
                errorFound = true;
                this.frmErrorProvider.SetError(this.txtDatabase, "Database cannot be empty");
            }

            if (this.rdoSql.Checked)
            {
                if(String.IsNullOrWhiteSpace(this.txtUserName.Text))
                {
                    errorFound = true;
                    this.frmErrorProvider.SetError(this.txtUserName, "User Name cannot be empty");
                }

                //allow empty password
            }
            else
            {
                //either Integrated or SQL should be checked
                if (!this.rdoIntegrated.Checked)
                {
                    errorFound = true;
                    this.frmErrorProvider.SetError(this.rdoIntegrated, "Please check an authentication type");

                }
            }

            return !errorFound;

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtUserName.Text))
            {
                this.frmErrorProvider.SetError(this.txtUserName, String.Empty);
            }
        }

    
        private void txtServer_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtServer.Text))
            {
                this.frmErrorProvider.SetError(this.txtServer, String.Empty);
            }
        }

        private void txtDatabase_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtDatabase.Text))
            {
                this.frmErrorProvider.SetError(this.txtDatabase, String.Empty);
            }
        }
    }
}
