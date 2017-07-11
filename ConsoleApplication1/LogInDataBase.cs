using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    public class LogInDataBase : ILogIn
    {

        public void LogMessage(string message, TypeLog type)
        {

                try
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        using (SqlCommand cmd = GetCommand(message, type, connection))
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            
        }

        private SqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }

        private SqlCommand GetCommand(string message, TypeLog type, SqlConnection connection)
        {
            string query = "Insert into Log Values(@message,@type)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@type", type);
            return command;
        }

    }
}
