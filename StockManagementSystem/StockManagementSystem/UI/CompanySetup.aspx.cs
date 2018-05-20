using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class CompanySetup : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            List<Company> companyList = companyManager.GetAllCompanies();
            if (companyList.Count > 0)
            {
                companyListGridView.DataSource = companyList;
                companyListGridView.DataBind();
            }
            else
            {
                companyListGridView.DataSource = null;
                companyListGridView.DataBind();
            }
        }

        protected void saveButton_Click1(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.CompanyName = companyTextBox.Text;
            if (aCompany.CompanyName != "")
            {
                companyMsgLabel.Text = companyManager.Save(aCompany);
            }
            else
            {
                companyMsgLabel.Text = "Compnay name can not be empty";
            }
            LoadGridView();
        }
        protected void productListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}