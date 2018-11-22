using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMMarketTrader.Models
{
    public class MarketSaleRecord
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public long Price { get; set; }
        public string username { get; set; }
        public DateTime Date { get; set; }
    }
}