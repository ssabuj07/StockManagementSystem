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
    public class ItemGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        public string Save(Item aItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            

            //string query = "INSERT INTO Item_tb (ItemName,ReorderLevel,CategoryId,CompanyId) VALUES ('" + aItem.ItemName + "','" + aItem.ReorderLevel + "','" + aItem.CategoryId + "','" + aItem.CompanyId + "')";
            // string query1 = "INSERT INTO StockIn_tb(StockInQuantity,ItemId) VALUES('" + 0 + "','" + aItem.ItemName + "')";

            string query = "INSERT INTO Item_tb (ItemName,ReorderLevel,CategoryId,CompanyId) VALUES( @a,@b, @c,@d )";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("a", SqlDbType.VarChar);
            command.Parameters["a"].Value = aItem.ItemName;
            command.Parameters.Add("b", SqlDbType.Int);
            command.Parameters["b"].Value = aItem.ReorderLevel;
            command.Parameters.Add("c", SqlDbType.Int);
            command.Parameters["c"].Value = aItem.CategoryId;
            command.Parameters.Add("d", SqlDbType.Int);
            command.Parameters["d"].Value = aItem.CompanyId;

            connection.Open();
            
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

        public void SaveQuantity(int itemQuantity, int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "UPDATE Item_tb SET Quantity = '" + itemQuantity + "' " +
                           "WHERE ItemId = '" + itemId + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public bool IsItemExist(string name, int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            //SELECT * FROM Customers WHERE Country IN (SELECT Country FROM Suppliers);

            //string query = "SELECT * FROM Item_tb WHERE ItemName='" + name + "' AND ('" + categoryId + "  IN (SELECT CategoryId FROM Item_tb WHERE ItemName='" + name + "') AND NOT CompanyId='" + categoryId + "') ";

            //string query = "SELECT * FROM Item_tb WHERE ItemName ='" + name + "' AND (CategoryId = '" + categoryId + "' OR CompanyId='" + categoryId + "') ";

            // string query = "IF NOT EXISTS (SELECT * FROM Item_tb WHERE CompanyId = '" + companyId +"' AND ItemName='" + name + "')"; 

            string query = "SELECT * FROM Item_tb WHERE ItemName = '" + name + "' AND  CompanyId ='" + companyId + "' ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
                // return false;
            }
            return false;
            //return true;
        }

        public List<Item> GetAllItems(int companyId)
        {
            string query = "SELECT * FROM Item_tb WHERE CompanyId = '" + companyId + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item aItem = new Item();
                aItem.ItemId = (int)reader["ItemId"];

                aItem.ItemName = reader["ItemName"].ToString();
                items.Add(aItem);
            }
            reader.Close();
            connection.Close();
            return items;
        }

        public Item GetItemById(int itemId)
        {
            //string query = "SELECT * FROM Item_tb WHERE ItemId = '" + itemId + "'";
            //string querySum = "SELECT SUM(StockInQuantity) FROM StockIn_tb WHERE ItemId = '" + itemId + "'";
            //string query = "SELECT * FROM Item_tb WHERE ItemId = '" + itemId + "'";

            string query = "SELECT * FROM Item_tb AS I INNER JOIN Total AS T ON I.ItemId = T.ItemId WHERE I.ItemId = '" + itemId + "' ";
            //string query = "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Item aiItem = null;
            if (reader.HasRows)
            {
                reader.Read();
                aiItem = new Item();
                aiItem.ItemId = (int)reader["ItemId"];
                aiItem.ItemName = reader["ItemName"].ToString();
                aiItem.ReorderLevel = (int)reader["ReorderLevel"];
                aiItem.Quantity = (int)reader["total_Quantity"];
            }
            reader.Close();

            //connection.Close();
            command.Connection.Close();
            if (aiItem != null)
            {
                return aiItem;
            }
            else
            {
                return getReorderLebel(itemId);
            }
        }

        public Item getReorderLebel(int itemId)
        {
            string query = "SELECT * FROM Item_tb WHERE ItemId = '" + itemId + "'";
            //string querySum = "SELECT SUM(StockInQuantity) FROM StockIn_tb WHERE ItemId = '" + itemId + "'";
            //string query = "SELECT * FROM Item_tb WHERE ItemId = '" + itemId + "'";

            //string query = "SELECT * FROM Item_tb AS I INNER JOIN Total AS T ON I.ItemId = T.ItemId WHERE I.ItemId = '" + itemId + "' ";
            //string query = "";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Item aiItem = null;
            if (reader.HasRows)
            {
                reader.Read();
                aiItem = new Item();
                aiItem.ItemId = (int)reader["ItemId"];
                aiItem.ItemName = reader["ItemName"].ToString();
                aiItem.ReorderLevel = (int)reader["ReorderLevel"];
                //aiItem.Quantity = 0;
                //aiItem.Quantity = (int)reader["total_Quantity"];
            }
            reader.Close();

            //connection.Close();
            command.Connection.Close();
            return aiItem;
        }

        public List<Company> GetallCompanies()
        {
            string query = "SELECT * FROM Company_tb INNER JOIN Item_tb ON Company_tb.CompanyId = Item_tb.CompanyId";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Company> companies = new List<Company>();
            while (reader.Read())
            {
                Company aCompany = new Company();
                aCompany.CompanyId = (int)reader["CompanyId"];

                aCompany.CompanyName = reader["CompanyName"].ToString();
                companies.Add(aCompany);
            }
            reader.Close();
            connection.Close();
            return companies;
        }

    }
}