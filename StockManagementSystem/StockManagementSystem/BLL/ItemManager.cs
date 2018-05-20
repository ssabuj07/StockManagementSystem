using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        CompanyGateway aCompanyGateway = new CompanyGateway();
        ItemGateway aItemGateway = new ItemGateway();

        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetallCompanies();
        }

        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetallCategories();
        }

        public List<Item> GetAllItems(int companyId)
        {
            return aItemGateway.GetAllItems(companyId);
        }



        public string Save(Item aItem)
        {
            if (IsItemExist(aItem.ItemName, aItem.CompanyId))
            {
                return "Item already exist to the perticular company!";
            }
            else
            {
                return aItemGateway.Save(aItem);
            }
        }

        //public void SaveQuantity(int itemQuantity, int itemId)
        //{
        //    aItemGateway.SaveQuantity(itemQuantity, itemId);
        //}

        public bool IsItemExist(string itemName, int companyId)
        {
            return aItemGateway.IsItemExist(itemName, companyId);
        }


        public Item GetItemById(int itemId)
        {
            return aItemGateway.GetItemById(itemId);
        }
    }
}