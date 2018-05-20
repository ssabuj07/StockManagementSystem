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
    public partial class Category2 : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadGridView();
        }

        private void LoadGridView()
        {
            List<Category> categorylList = categoryManager.GetAllCategories();
            if (categorylList.Count > 0)
            {
                
                //categoryListGridView.DataSourceID = SqlDataSource1.ToString();
                categoryListGridView.DataBind();
            }
            else
            {
               // categoryListGridView.DataSourceID = SqlDataSource1.ToString();
               categoryListGridView.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category aCategory = new Category();
            aCategory.CategoryName = categoryTextBox.Text;
            if (aCategory.CategoryName != "")
            {
                msgLabel.Text = categoryManager.Save(aCategory);
            }
            else
            {
                msgLabel.Text = "Category name can not be empty";
            }
            //categoryListGridView.
            LoadGridView();
        }


    }
}