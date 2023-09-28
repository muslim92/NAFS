using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFS.Models;

namespace NAFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LtdCompaniesController : ControllerBase
    {
        private readonly Context _context;

        public LtdCompaniesController(Context context)
        {
            _context = context;
        }

        // GET: api/LtdCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LtdCompanies>>> GetLtdCompanies()
        {
            if (_context.LtdCompanies == null)
            {
                return NotFound();
            }
            return await _context.LtdCompanies.ToListAsync();
        }


        // GET: api/LtdCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LtdCompanies>> GetLtdCompanies(int id)
        {
          if (_context.LtdCompanies == null)
          {
              return NotFound();
          }
            var ltdCompanies = await _context.LtdCompanies.FindAsync(id);

            if (ltdCompanies == null)
            {
                return NotFound();
            }

            return ltdCompanies;
        }

        // PUT: api/LtdCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLtdCompanies(int id, LtdCompanies ltdCompanies)
        {
            if (id != ltdCompanies.id)
            {
                return BadRequest();
            }

            _context.Entry(ltdCompanies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LtdCompaniesExists(id))
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

        // POST: api/LtdCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LtdCompanies>> PostLtdCompanies(LtdCompanies ltdCompanies)
        {
          if (_context.LtdCompanies == null)
          {
              return Problem("Entity set 'Context.LtdCompanies'  is null.");
          }
            _context.LtdCompanies.Add(ltdCompanies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLtdCompanies", new { id = ltdCompanies.id }, ltdCompanies);
        }

        // DELETE: api/LtdCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLtdCompanies(int id)
        {
            if (_context.LtdCompanies == null)
            {
                return NotFound();
            }
            var ltdCompanies = await _context.LtdCompanies.FindAsync(id);
            if (ltdCompanies == null)
            {
                return NotFound();
            }

            _context.LtdCompanies.Remove(ltdCompanies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LtdCompaniesExists(int id)
        {
            return (_context.LtdCompanies?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
