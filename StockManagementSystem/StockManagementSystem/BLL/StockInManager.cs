using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;

namespace StockManagementSystem.BLL
{
    public class StockInManager
    {
        StockInGateway aStockInGateway = new StockInGateway();
        public void SaveQuantity(int itemQuantity, int itemId)
        {
            aStockInGateway.SaveQuantity(itemQuantity, itemId);
        }


    }
}