using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
    public class SearchAndViewManager
    {
        SearchAndViewGateway aSearchAndViewGateway = new SearchAndViewGateway();

        public List<ViewItemSummary> ViewItemSummaries(int companyId, int categoryId)
        {
            return aSearchAndViewGateway.ViewItemSummaries(companyId, categoryId);
        }
    }
}