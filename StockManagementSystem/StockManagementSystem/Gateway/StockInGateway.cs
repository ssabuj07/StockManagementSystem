using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystem.Gateway
{
    public class StockInGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        public void SaveQuantity(int itemQuantity, int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
           // string query = "INSERT INTO StockIn_tb(StockInQuantity,ItemId) VALUES ('" + itemQuantity + "', '" + itemId + "' ) ";
            string query = "INSERT INTO StockIn_tb(StockInQuantity,ItemId) VALUES( @a,@b)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("a", SqlDbType.Int);
            command.Parameters["a"].Value = itemQuantity;
            command.Parameters.Add("b", SqlDbType.Int);
            command.Parameters["b"].Value = itemId;

            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}