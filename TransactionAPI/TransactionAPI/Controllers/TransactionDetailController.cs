using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionAPI.Models;

namespace TransactionAPI.controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly TransactionDetailContext _context;

        public TransactionDetailController(TransactionDetailContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDetail>>> GetDistinctByDeedNo()
        {
            // Fetch all transactions
            var allTransactions = await _context.TransactionDetail.ToListAsync();

            // Use LINQ to group by DEED_INO and select the most recent from each group
            var distinctTransactions = allTransactions
                .GroupBy(t => t.DEED_INO)
                .Select(group => group.OrderByDescending(t => t.LOG_CREATED_TS).First())
                .ToList();

            return distinctTransactions;
        }


        // GET: api/TransactionDetail
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDetail>>> GetTransactionDetail()
        {
          if (_context.TransactionDetail == null)
          {
              return NotFound();
          }
            return await _context.TransactionDetail.ToListAsync();
        }*/

        // GET: api/TransactionDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDetail>> GetTransactionDetail(int id)
        {
          if (_context.TransactionDetail == null)
          {
              return NotFound();
          }
            var transactionDetail = await _context.TransactionDetail.FindAsync(id);

            if (transactionDetail == null)
            {
                return NotFound();
            }

            return transactionDetail;
        }

        // PUT: api/TransactionDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionDetail(int id, TransactionDetail transactionDetail)
        {
            if (id != transactionDetail.TransactionDetailId)
            {
                return BadRequest();
            }

            _context.Entry(transactionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionDetailExists(id))
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

        // POST: api/TransactionDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionDetail>> PostTransactionDetail(TransactionDetail transactionDetail)
        {
          if (_context.TransactionDetail == null)
          {
              return Problem("Entity set 'TransactionDetailContext.TransactionDetail'  is null.");
          }
            _context.TransactionDetail.Add(transactionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionDetail", new { id = transactionDetail.TransactionDetailId }, transactionDetail);
        }

        // DELETE: api/TransactionDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionDetail(int id)
        {
            if (_context.TransactionDetail == null)
            {
                return NotFound();
            }
            var transactionDetail = await _context.TransactionDetail.FindAsync(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            _context.TransactionDetail.Remove(transactionDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionDetailExists(int id)
        {
            return (_context.TransactionDetail?.Any(e => e.TransactionDetailId == id)).GetValueOrDefault();
        }
    }
}
