using System;
using System.Linq;
using System.Data.SqlClient;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Utility
{
    public static class SqlConnectionTester
    {

        public static ConnectionTestResult TestConnectionString(string connectionString, bool closeConnection = false)
        {

            var result = new ConnectionTestResult();

            if (!String.IsNullOrWhiteSpace(connectionString))
            {


                SqlConnection sqlConnection = new SqlConnection(connectionString);

                try
                {
                    sqlConnection.Open();

                    if (closeConnection)
                    {
                        sqlConnection.Close();
                    }


                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = ex.Message;
                }

            }
            else
            {
                result.Success = false;
                result.ErrorMessage = "Connection string cannot be empty";
            }

            return result;
        }
    }
}
