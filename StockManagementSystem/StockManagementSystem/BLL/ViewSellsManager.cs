using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class ViewSellsManager
    {
        ViewSellsGateway aViewSellsGateway = new ViewSellsGateway();
        public List<ViewSells> ViewSellses(DateTime fromDate, DateTime toDate)
        {
            return aViewSellsGateway.ViewSellses(fromDate, toDate);
        }
    }
}