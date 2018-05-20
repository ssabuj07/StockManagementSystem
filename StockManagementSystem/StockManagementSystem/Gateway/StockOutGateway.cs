using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    public class StockOutGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        public string SaveSell(List<StockOutM> aStockOutMs, String type)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;

            int row = 0;
            connection.Open();
            foreach (StockOutM aSell in aStockOutMs)
            {
                //string query = "INSERT INTO StockOut_tb (StockOutQuantity,Date,Type,ItemId) VALUES ('" + aSell.SellQuantity + "','" + aSell.Date + "','" + type + "','" + aSell.ItemId + "')";
                string query = "INSERT INTO StockOut_tb (StockOutQuantity,Date,Type,ItemId) VALUES ( @a,@b,@c,@d)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Clear();

                command.Parameters.Add("a", SqlDbType.Int);
                command.Parameters["a"].Value = aSell.SellQuantity;
                command.Parameters.Add("b", SqlDbType.Date);
                command.Parameters["b"].Value = aSell.Date;
                command.Parameters.Add("c", SqlDbType.VarChar);
                command.Parameters["c"].Value = type;
                command.Parameters.Add("d", SqlDbType.Int);
                command.Parameters["d"].Value = aSell.ItemId;

                row = command.ExecuteNonQuery();
            }
            
            if (row > 0)
            {
                return "Saved";
            }
            else
            {
                return "Failed";
            }
            // return "ok";
        }

        public int GetStockOutQuantityByItemId(int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Total_StockOut WHERE ItemId='" + itemId + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                StockOutM aStockOutM = new StockOutM();
                aStockOutM.SellQuantity = (int)reader["StockOutQuantity"];
                //int quantity = (int) reader["StockOutQuantity"];
                int quantity = aStockOutM.SellQuantity;
                return quantity;
            }
            else
            {
                return 0;
            }
        }

        public StockOutM GetDummyAvailableItemQuantityById(int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM DummyAvailableQuantity WHERE ItemId='" + itemId + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                StockOutM aStockOutM = new StockOutM();
                aStockOutM.DummyAvailableQuantity = (int)reader["AvailableQuantity"];
                //int quantity = (int) reader["StockOutQuantity"];
                //int quantity = aStockOutM.SellQuantity;
                return aStockOutM;
            }
            else
            {
                StockOutM aStockOutM = new StockOutM();
                aStockOutM.DummyAvailableQuantity=0;
                return aStockOutM;
            }
        }

        public void SaveDummyUpdatedAvailableQuantity(int itemId, int newAvailableQuantity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "UPDATE DummyAvailableQuantity SET AvailableQuantity = '" + newAvailableQuantity + "', WHERE ItemId = '" + itemId + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}