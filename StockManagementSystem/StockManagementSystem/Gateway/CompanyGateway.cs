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
    public class CompanyGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockDbConnectionString"].ConnectionString;
        public string Save(Company aCompany)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            //string query = "INSERT INTO Company_tb (CompanyName) VALUES ('" + aCompany.CompanyName + "')";

            string query = "INSERT INTO Company_tb (CompanyName) VALUES( @a )";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("a", SqlDbType.VarChar);
            command.Parameters["a"].Value = aCompany.CompanyName;
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

        public bool IsCompanyNameExist(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Company_tb WHERE CompanyName='" + name + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public List<Company> GetallCompanies()
        {
            string query = "SELECT * FROM Company_tb";
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