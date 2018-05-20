using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.Model
{
    [Serializable]
    public class StockOutM
    {
        public int DummyAvailableQuantity { get; set; }
        public int SellQuantity { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
    }
}