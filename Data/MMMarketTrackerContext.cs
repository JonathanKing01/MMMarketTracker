using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMMarketTrader.Models;

namespace MMMarketTracker.Models
{
    public class MMMarketTrackerContext : DbContext
    {
        public MMMarketTrackerContext (DbContextOptions<MMMarketTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<MMMarketTrader.Models.MarketSaleRecord> MarketSaleRecord { get; set; }
    }
}
