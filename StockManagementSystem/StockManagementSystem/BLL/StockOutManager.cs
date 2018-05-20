using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway = new StockOutGateway();
        public string SaveSell(List<StockOutM> aStockOuts, string type)
        {
            return aStockOutGateway.SaveSell(aStockOuts, type);
        }

        public int GetStockOutQuantityByItemId(int itemId)
        {
            return aStockOutGateway.GetStockOutQuantityByItemId(itemId);
        }

        public StockOutM GetDummyAvailableItemQuantityById(int itemId)
        {
            return aStockOutGateway.GetDummyAvailableItemQuantityById(itemId);
        }

        public void SaveDummyUpdatedAvailableQuantity(int itemId, int newAvailableQuantity)
        {
            aStockOutGateway.SaveDummyUpdatedAvailableQuantity(itemId, newAvailableQuantity);
        }

    }
}