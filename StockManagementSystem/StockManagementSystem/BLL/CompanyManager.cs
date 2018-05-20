using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        private CompanyGateway aCompanyGateway = new CompanyGateway();

        public string Save(Company aCompany)
        {
            if (IsCompanyNameExist(aCompany.CompanyName))
            {
                return "Company name already exist!";
            }
            else
            {
                return aCompanyGateway.Save(aCompany);
            }
        }
        public bool IsCompanyNameExist(string companyName)
        {
            return aCompanyGateway.IsCompanyNameExist(companyName);
        }

        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetallCompanies();
        }
    }
}