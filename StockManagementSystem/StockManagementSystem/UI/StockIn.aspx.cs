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
    public partial class StockIn : System.Web.UI.Page
    {
        StockInManager aStockInManager = new StockInManager();
        ItemManager aItemManager = new ItemManager();
        StockOutManager aStockOutManager = new StockOutManager();
        //Item _aItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Company> companies = aItemManager.GetAllCompanies();
                stockInCompanyDropDownList.DataSource = companies;
                stockInCompanyDropDownList.DataTextField = "CompanyName";
                stockInCompanyDropDownList.DataValueField = "CompanyId";
                stockInCompanyDropDownList.DataBind();

                int companyId = Convert.ToInt32(stockInCompanyDropDownList.SelectedValue);

                List<Item> allItems = aItemManager.GetAllItems(companyId);
                stockInItemDropDownList.DataSource = allItems;
                stockInItemDropDownList.DataTextField = "ItemName";
                stockInItemDropDownList.DataValueField = "ItemId";
                stockInItemDropDownList.DataBind();

                if (stockInItemDropDownList.SelectedValue != "")
                {
                    int itemId = Convert.ToInt32(stockInItemDropDownList.SelectedValue);

                    Item aItem = aItemManager.GetItemById(itemId);


                    showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                    showAvailableQuantityTextBox.Text = aItem.Quantity.ToString(); //quantity in another table
                }
                else
                {
                    stockInQuantityTextBox.ReadOnly = true;
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(stockInItemDropDownList.SelectedValue);
            
            int stockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
           // aItem.Quantity += stockInQuantity;
            aStockInManager.SaveQuantity(stockInQuantity, itemId);
            Item aItem = aItemManager.GetItemById(itemId);
            int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);
            showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
            showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
            stockInQuantityTextBox.Text = "";
        }

        protected void stockInCompanyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(stockInCompanyDropDownList.SelectedValue);

            List<Item> allItems = aItemManager.GetAllItems(companyId);
            stockInItemDropDownList.DataSource = allItems;
            stockInItemDropDownList.DataTextField = "ItemName";
            stockInItemDropDownList.DataValueField = "ItemId";
            stockInItemDropDownList.DataBind();

            if (stockInItemDropDownList.SelectedValue != "")
            {
                int itemId = Convert.ToInt32(stockInItemDropDownList.SelectedValue);

                Item aItem = aItemManager.GetItemById(itemId);

                int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);
                showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
                showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                //showAvailableQuantityTextBox.Text = aItem.Quantity.ToString();
                stockInQuantityTextBox.ReadOnly = false;
            }
            else
            {
                showReorderLevelTextBox.Text = "";
                showAvailableQuantityTextBox.Text = "";
                stockInQuantityTextBox.Text = "";
                stockInQuantityTextBox.ReadOnly = true;
                
            }

        }

        protected void stockInItemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(stockInItemDropDownList.SelectedValue);

            Item aItem = aItemManager.GetItemById(itemId);

            int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);

            showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
            showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
            //showAvailableQuantityTextBox.Text = aItem.Quantity.ToString();
            //showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
            //showAvailableQuantityTextBox.Text = aItem.Quantity.ToString();
        }
    }
}