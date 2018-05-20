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
    public partial class SearchAndView : System.Web.UI.Page
    {
        ItemManager aItemManager = new ItemManager();
        SearchAndViewManager aSearchAndViewManager = new SearchAndViewManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = aItemManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();

                List<Category> allCategories = aItemManager.GetAllCategories();
                categoryDropDownList.DataSource = allCategories;
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryId";
                categoryDropDownList.DataBind();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            itemSummaryMsgLabel.Text = "";
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            int categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            List<ViewItemSummary> itemSummaries = aSearchAndViewManager.ViewItemSummaries(companyId, categoryId);
            if (itemSummaries.Count != 0)
            {
                searchItemListGridView.DataSource = itemSummaries;
                searchItemListGridView.DataBind();
            }
            else
            {
                itemSummaryMsgLabel.Text = "No item is found";
                searchItemListGridView.DataSource = null;
                searchItemListGridView.DataBind();
            }
        }
    }
}