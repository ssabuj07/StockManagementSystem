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
    public class CategoryGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        public string Save(Category aCategory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
           // string query = "INSERT INTO Category (CategoryName) VALUES ('" + aCategory.CategoryName + "')";
            string query = "INSERT INTO Category (CategoryName) VALUES(@a )";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();



            command.Parameters.Add("a", SqlDbType.VarChar);
            command.Parameters["a"].Value = aCategory.CategoryName;
            //command.Parameters.Add("b", SqlDbType.VarChar);
            //command.Parameters["b"].Value = city.About;
            //command.Parameters.Add("c", SqlDbType.VarChar);
            //command.Parameters["c"].Value = city.Country; 

            int row = command.ExecuteNonQuery();
            if (row > 0)
            {
                return "Saved";
            }
            else
            {
                return "Failed";
            }
        }

        public bool IsCategoryNameExist(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Category WHERE CategoryName='" + name + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public List<Category> GetallCategories()
        {
            string query = "SELECT * FROM Category";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category aCategory = new Category();
                aCategory.CategoryId = (int)reader["CategoryId"];

                aCategory.CategoryName = reader["CategoryName"].ToString();
                categories.Add(aCategory);
            }
            reader.Close();
            connection.Close();
            return categories;
        }

        //public int Update(Product product)
        //{
        //    string query = "UPDATE Product SET Name = '" + product.ProductName + "', UnitPrice = '" + product.UnitPrice + "', Quantity = '" + product.Quantity + "' WHERE ProductId = '" + product.ProductId + "'";
        //    SqlConnection connection = new SqlConnection();
        //    connection.ConnectionString = connectionstring;
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    int rowAffected = command.ExecuteNonQuery();
        //    connection.Close();
        //    return rowAffected;
        //}
    }
}