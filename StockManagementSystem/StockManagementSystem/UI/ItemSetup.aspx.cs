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
    public partial class ItemSetup : System.Web.UI.Page
    {
        ItemManager aItemManager = new ItemManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = aItemManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();

                List<Category> categoryList = aItemManager.GetAllCategories();
                categoryDropDownList.DataSource = categoryList;
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryId";
                categoryDropDownList.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();
            aItem.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            aItem.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            aItem.ItemName = itemNameTextBox.Text;
            if (itemReorderLevelTextBox.Text != "")
            {
                aItem.ReorderLevel = Convert.ToInt32(itemReorderLevelTextBox.Text);
            }
            if (aItem.ItemName != "")
            {
                ItemMsgLabel.Text = aItemManager.Save(aItem);
            }
            else
            {
                ItemMsgLabel.Text = @"Item name can not be empty";
            }
            itemNameTextBox.Text = "";
            itemReorderLevelTextBox.Text = "";
        }
    }
}