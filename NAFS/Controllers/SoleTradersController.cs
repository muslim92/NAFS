using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFS.Models;

namespace NAFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoleTradersController : ControllerBase
    {
        private readonly Context _context;

        public SoleTradersController(Context context)
        {
            _context = context;
        }

        // GET: api/SoleTraders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoleTraders>>> GetSoleTraders()
        {
          if (_context.SoleTraders == null)
          {
              return NotFound();
          }
            return await _context.SoleTraders.ToListAsync();
        }

        // GET: api/SoleTraders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoleTraders>> GetSoleTraders(int id)
        {
          if (_context.SoleTraders == null)
          {
              return NotFound();
          }
            var soleTraders = await _context.SoleTraders.FindAsync(id);

            if (soleTraders == null)
            {
                return NotFound();
            }

            return soleTraders;
        }

        // PUT: api/SoleTraders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoleTraders(int id, SoleTraders soleTraders)
        {
            if (id != soleTraders.id)
            {
                return BadRequest();
            }

            _context.Entry(soleTraders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoleTradersExists(id))
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

        // POST: api/SoleTraders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoleTraders>> PostSoleTraders(SoleTraders soleTraders)
        {
          if (_context.SoleTraders == null)
          {
              return Problem("Entity set 'Context.SoleTraders'  is null.");
          }
            _context.SoleTraders.Add(soleTraders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoleTraders", new { id = soleTraders.id }, soleTraders);
        }

        // DELETE: api/SoleTraders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoleTraders(int id)
        {
            if (_context.SoleTraders == null)
            {
                return NotFound();
            }
            var soleTraders = await _context.SoleTraders.FindAsync(id);
            if (soleTraders == null)
            {
                return NotFound();
            }

            _context.SoleTraders.Remove(soleTraders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoleTradersExists(int id)
        {
            return (_context.SoleTraders?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
