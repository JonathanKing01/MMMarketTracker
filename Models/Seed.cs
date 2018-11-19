using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MMMarketTrader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMMarketTracker.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MMMarketTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<MMMarketTrackerContext>>()))
            {
                if (context.MarketSaleRecord.Count() > 0)
                {
                    return; 
                }
                    
                    context.MarketSaleRecord.AddRange(
                    new MarketSaleRecord
                    {
                        Item = "Ogre ring",
                        Price = 90000000,
                        Date = (new DateTime())
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
