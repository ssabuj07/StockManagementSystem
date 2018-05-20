using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    public class ViewSellsGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;

        public List<ViewSells> ViewSellses(DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT * FROM Item_tb AS i INNER JOIN StockOut_tb AS st ON i.ItemId = st.ItemId WHERE st.Date BETWEEN '" + fromDate + "' AND '" + toDate + "' AND st.Type='sell' ";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewSells> ViewSellses = new List<ViewSells>();
            while (reader.Read())
            {
                ViewSells aViewSell = new ViewSells();
                aViewSell.ItemName = reader["ItemName"].ToString();
                aViewSell.SellQuantity = (int)reader["StockOutQuantity"];
                ViewSellses.Add(aViewSell);
            }
            reader.Close();
            connection.Close();
            return ViewSellses;
        }
    }
}