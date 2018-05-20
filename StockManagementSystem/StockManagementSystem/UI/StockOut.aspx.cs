using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class StockOut : System.Web.UI.Page
    {
        ItemManager aItemManager = new ItemManager();
        List<StockOutM> stockOuts = null;
        Dictionary<int, int> dummyDictionary = null;
        StockOutManager aStockOutManager = new StockOutManager();
        //Item _aItem;
        //List<DataTable> dt = new List<DataTable>(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //stockOuts = new List<StockOutM>();
                LoadGridView();
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(stockOutItemDropDownList.SelectedValue);


            //Item aItem = aItemManager.GetItemById(itemId);
            //int totalstockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);

            //int availableQuentity = aItem.Quantity - totalstockOutQuantity;


            int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("M/d/yyyy"));
            //DateTime date = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
            // DataTable table=null;
            // List<StockOutM> stockOuts = null;

            StockOutM aStockOutM = new StockOutM();
            aStockOutM = aStockOutManager.GetDummyAvailableItemQuantityById(itemId);
            if (ViewState["dictionary"] == null)
            {
                dummyDictionary = new Dictionary<int, int>();
            }
            else
            {
                dummyDictionary = (Dictionary<int, int>)ViewState["dictionary"];
                //dummyDictionary.Add(itemId, aStockOutM.DummyAvailableQuantity);
            }
            if (!dummyDictionary.ContainsKey(itemId))
            {
                //dummyDictionary.Add(itemId, aStockOutM.DummyAvailableQuantity - stockOutQuantity);
                //ViewState["dictionary"] = dummyDictionary;
                //if (dummyDictionary[itemId] >= 0)
                if (aStockOutM.DummyAvailableQuantity - stockOutQuantity >= 0)
                {
                    stockOutMsgLabel.Text = "";
                    dummyDictionary.Add(itemId, aStockOutM.DummyAvailableQuantity - stockOutQuantity);
                    ViewState["dictionary"] = dummyDictionary;
                    if (ViewState["list"] == null)
                    {
                        stockOuts = new List<StockOutM>();
                        //dt = (List<DataTable>) ViewState["dt"];
                    }
                    else
                    {
                        stockOuts = (List<StockOutM>)ViewState["list"];
                        //DataTable table = new DataTable();
                    }

                    StockOutM aStockOut = new StockOutM();

                    //aSell.Type = "sdff";
                    aStockOut.Date = date;
                    aStockOut.ItemId = itemId;
                    aStockOut.ItemName = stockOutItemDropDownList.SelectedItem.Text;
                    aStockOut.CompanyName = stockOutCompanyDropDownList.SelectedItem.Text;
                    aStockOut.SellQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                    stockOuts.Add(aStockOut);

                    ViewState["list"] = stockOuts;
                    stockOutGridView.DataSource = stockOuts;
                    stockOutGridView.DataBind();
                }
                else
                {
                    stockOutMsgLabel.Text = "The item is not in Enough quantity";
                }
            }
            else
                foreach (KeyValuePair<int, int> aKeyValuePair in dummyDictionary)
                {
                    if (aKeyValuePair.Key == itemId)
                    {
                        int value = aKeyValuePair.Value - stockOutQuantity;
                        
                        // Update dictionary value
                        if (value >= 0)
                        {
                            dummyDictionary.Remove(aKeyValuePair.Key);
                            dummyDictionary.Add(aKeyValuePair.Key, value);
                        }

                        //dummyDictionary.Add(aKeyValuePair.Key, value);

                        ViewState["dictionary"] = dummyDictionary;
                        if (value >= 0)
                        {
                            stockOutMsgLabel.Text = "";

                            if (ViewState["list"] == null)
                            {
                                stockOuts = new List<StockOutM>();
                                //dt = (List<DataTable>) ViewState["dt"];
                            }
                            else
                            {
                                stockOuts = (List<StockOutM>) ViewState["list"];
                                //DataTable table = new DataTable();
                            }

                            StockOutM aStockOut = new StockOutM();

                            //aSell.Type = "sdff";
                            aStockOut.Date = date;
                            aStockOut.ItemId = itemId;
                            aStockOut.ItemName = stockOutItemDropDownList.SelectedItem.Text;
                            aStockOut.CompanyName = stockOutCompanyDropDownList.SelectedItem.Text;
                            aStockOut.SellQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                            stockOuts.Add(aStockOut);

                            ViewState["list"] = stockOuts;
                            stockOutGridView.DataSource = stockOuts;
                            stockOutGridView.DataBind();
                        }
                        else
                        {
                            stockOutMsgLabel.Text = "The item is not in Enough quantity";
                        }
                        break;
                    }
                    
                }
            //Dictionary<int,int> dummyDictionary = new Dictionary<int, int>();
            //dummyDictionary.Add(itemId, aStockOutM.DummyAvailableQuantity); 
            //if (aStockOutM.DummyAvailableQuantity - stockOutQuantity >= 0)
            //{

            //    // aStockOutManager.SaveDummyUpdatedAvailableQuantity(itemId, aStockOutM.DummyAvailableQuantity - stockOutQuantity);
            //}
            //else
            //{
            //    Response.Write("The Item is Stock Out.");
            //}
            stockOutQuantityTextBox.Text = "";

        }

        protected void stockOutCompanyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(stockOutCompanyDropDownList.SelectedValue);

            List<Item> allItems = aItemManager.GetAllItems(companyId);
            stockOutItemDropDownList.DataSource = allItems;
            stockOutItemDropDownList.DataTextField = "ItemName";
            stockOutItemDropDownList.DataValueField = "ItemId";
            stockOutItemDropDownList.DataBind();

            if (stockOutItemDropDownList.SelectedValue != "")
            {
                int itemId = Convert.ToInt32(stockOutItemDropDownList.SelectedValue);

                Item aItem = aItemManager.GetItemById(itemId);
                int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);

                showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
                showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                //showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                //showAvailableQuantityTextBox.Text = aItem.Quantity.ToString();
                stockOutQuantityTextBox.ReadOnly = false;
            }
            else
            {
                showReorderLevelTextBox.Text = "";
                showAvailableQuantityTextBox.Text = "";
                stockOutQuantityTextBox.ReadOnly = true;

            }

        }

        protected void stockOutItemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(stockOutItemDropDownList.SelectedValue);

            Item aItem = aItemManager.GetItemById(itemId);
            int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);

            showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
            showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            string type = "sell";
            stockOuts = (List<StockOutM>)ViewState["list"];
            aStockOutManager.SaveSell(stockOuts, type);
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            LoadGridView();
            ViewState["list"] = null;
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            string type = "damage";
            stockOuts = (List<StockOutM>)ViewState["list"];
            aStockOutManager.SaveSell(stockOuts, type);
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            LoadGridView();
            ViewState["list"] = null;
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            string type = "lost";
            stockOuts = (List<StockOutM>)ViewState["list"];
            aStockOutManager.SaveSell(stockOuts, type);
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            LoadGridView();
            ViewState["list"] = null;
        }

        public void LoadGridView()
        {
            List<Company> companies = aItemManager.GetAllCompanies();
            stockOutCompanyDropDownList.DataSource = companies;
            stockOutCompanyDropDownList.DataTextField = "CompanyName";
            stockOutCompanyDropDownList.DataValueField = "CompanyId";
            stockOutCompanyDropDownList.DataBind();

            int companyId = Convert.ToInt32(stockOutCompanyDropDownList.SelectedValue);

            List<Item> allItems = aItemManager.GetAllItems(companyId);
            stockOutItemDropDownList.DataSource = allItems;
            stockOutItemDropDownList.DataTextField = "ItemName";
            stockOutItemDropDownList.DataValueField = "ItemId";
            stockOutItemDropDownList.DataBind();

            if (stockOutItemDropDownList.SelectedValue != "")
            {
                int itemId = Convert.ToInt32(stockOutItemDropDownList.SelectedValue);

                Item aItem = aItemManager.GetItemById(itemId);
                int stockOutQuantity = aStockOutManager.GetStockOutQuantityByItemId(itemId);
                showAvailableQuantityTextBox.Text = (aItem.Quantity - stockOutQuantity).ToString();
                showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();


                //showReorderLevelTextBox.Text = aItem.ReorderLevel.ToString();
                //showAvailableQuantityTextBox.Text = aItem.Quantity.ToString();
            }
            else
            {
                showReorderLevelTextBox.Text = "";
                showAvailableQuantityTextBox.Text = "";
            }
        }
    }
}