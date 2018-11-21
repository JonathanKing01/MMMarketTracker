using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMMarketTracker.Models;
using MMMarketTrader.Models;

namespace MMMarketTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/MarketSaleRecord")]
    public class MarketSaleRecordsController : Controller
    {
        private readonly MMMarketTrackerContext _context;

        public MarketSaleRecordsController(MMMarketTrackerContext context)
        {
            _context = context;
        }

        // GET: api/MarketSaleRecords
        //[HttpGet]
        //public IEnumerable<MarketSaleRecord> GetMarketSaleRecord()
        //{
        //    return _context.MarketSaleRecord;
        //}

        // GET: api/MarketSaleRecords
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarketSaleRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marketSaleRecord = await _context.MarketSaleRecord.SingleOrDefaultAsync(m => m.Id == id);

            if (marketSaleRecord == null)
            {
                return NotFound();
            }

            return Ok(marketSaleRecord);
        }

        // GET: api/MarketSaleRecords
        [HttpGet]
        public async Task<IActionResult> GetMarketSaleRecordFromItemName(string item)
        {
            item = item.ToUpper();
            IQueryable<MarketSaleRecord> sales = (from m in _context.MarketSaleRecord
                                                  where m.Item.ToUpper().Contains(item)
                                                  select m);
            
            var returned = await sales.ToListAsync();

            return Ok(returned);
        }

        // GET: api/MarketSaleRecords/Item
        [Route("items")]
        [HttpGet]
        public async Task<List<string>> GetItems()
        {
            var sales = (from m in _context.MarketSaleRecord
                         select m.Item).Distinct();

            var returned = await sales.ToListAsync();

            return returned;
        }

        [Route("itemSearch/{name}")]
        [HttpGet]
        public async Task<List<string>> GetItems([FromRoute]string name)
        {
            name = name.ToUpper();
            var sales = (from m in _context.MarketSaleRecord
                         where m.Item.ToUpper().Contains(name)
                         select m.Item).Distinct();

            var returned = await sales.ToListAsync();

            return returned;
        }

        // PUT: api/MarketSaleRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketSaleRecord([FromRoute] int id, [FromBody] MarketSaleRecord marketSaleRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marketSaleRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(marketSaleRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketSaleRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MarketSaleRecords
        [HttpPost]
        public async Task<IActionResult> PostMarketSaleRecord([FromBody] MarketSaleRecord marketSaleRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MarketSaleRecord.Add(marketSaleRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketSaleRecord", new { id = marketSaleRecord.Id }, marketSaleRecord);
        }

        // DELETE: api/MarketSaleRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketSaleRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marketSaleRecord = await _context.MarketSaleRecord.SingleOrDefaultAsync(m => m.Id == id);
            if (marketSaleRecord == null)
            {
                return NotFound();
            }

            _context.MarketSaleRecord.Remove(marketSaleRecord);
            await _context.SaveChangesAsync();

            return Ok(marketSaleRecord);
        }

        private bool MarketSaleRecordExists(int id)
        {
            return _context.MarketSaleRecord.Any(e => e.Id == id);
        }
    }
}