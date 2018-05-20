using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    public class SearchAndViewGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;

        public List<ViewItemSummary> ViewItemSummaries(int companyId, int categoryId)
        {
            //string query =
            //    "Select i.ItemName,c.CompanyName,i.Quantity,i.ReorderLevel from Item_tb as i INNER JOIN Company_tb as c ON i.CompanyId=c.CompanyId WHERE i.CompanyId='" +
            //    companyId + "' AND i.CategoryId ='" + categoryId + "' ";

            //string query =
            //    "Select i.ItemName,c.CompanyName,t.total_Quantity, st.StockOutQuantity,i.ReorderLevel from Item_tb as i INNER JOIN Company_tb as c ON i.CompanyId=c.CompanyId INNER JOIN Total AS t ON i.ItemId=t.ItemId INNER JOIN Total_StockOut AS st ON i.ItemId=st.ItemId WHERE i.CompanyId='" +
            //    companyId + "' AND i.CategoryId ='" + categoryId + "' ";

            string query =
                "Select i.ItemId, i.ItemName, c.CompanyName, ct.CategoryName , t.total_Quantity, st.StockOutQuantity,i.ReorderLevel from Item_tb as i LEFT JOIN Company_tb as c ON i.CompanyId=c.CompanyId LEFT JOIN Category AS ct ON i.CategoryId = ct.CategoryId LEFT JOIN Total AS t ON i.ItemId=t.ItemId LEFT JOIN Total_StockOut AS st ON i.ItemId=st.ItemId WHERE i.CompanyId='" +
                companyId + "' AND i.CategoryId ='" + categoryId + "' ";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewItemSummary> viewItemSummaries = new List<ViewItemSummary>();

            while (reader.Read())
            {
                ViewItemSummary aViewItemSummary = new ViewItemSummary();
                aViewItemSummary.ItemName = reader["ItemName"].ToString();
                aViewItemSummary.CompanyName = reader["CompanyName"].ToString();
                aViewItemSummary.CategoryName = reader["CategoryName"].ToString();
                //aViewItemSummary.StockOutQuantity = (int) reader["StockOutQuantity"];
                string stockOutQuantity = reader["StockOutQuantity"].ToString();
                if (stockOutQuantity != "")
                {
                    aViewItemSummary.StockOutQuantity = (int)reader["StockOutQuantity"];
                }
                else
                {
                    aViewItemSummary.StockOutQuantity = 0;
                }
                string totalQuantity = reader["total_Quantity"].ToString();
                if (totalQuantity != "")
                {
                    aViewItemSummary.AvailableQuantity = (int)reader["total_Quantity"] - aViewItemSummary.StockOutQuantity;
                }
                else
                {
                    aViewItemSummary.AvailableQuantity = 0;
                }
                aViewItemSummary.ReorderLevel = (int)reader["ReorderLevel"];
                viewItemSummaries.Add(aViewItemSummary);
            }
            reader.Close();
            connection.Close();
            return viewItemSummaries;
        }
    }
}