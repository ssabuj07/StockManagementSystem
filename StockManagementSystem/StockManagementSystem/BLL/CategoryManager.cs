using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        private CategoryGateway aCategoryGateway = new CategoryGateway();

        public string Save(Category aCategory)
        {
            if (IsCategoryNameExist(aCategory.CategoryName))
            {
                return "Category Name already exist!";
            }
            else
            {
                return aCategoryGateway.Save(aCategory);
            }
        }
        public bool IsCategoryNameExist(string categoryName)
        {
            return aCategoryGateway.IsCategoryNameExist(categoryName);
        }

        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetallCategories();
        }
    }
}