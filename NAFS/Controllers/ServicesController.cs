using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFS.Models;

namespace NAFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly Context _context;

        public ServicesController(Context context)
        {
            _context = context;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
          if (_context.Service == null)
          {
              return NotFound();
          }
            return await _context.Service.ToListAsync();
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServices(int id)
        {
          if (_context.Service == null)
          {
              return NotFound();
          }
            var services = await _context.Service.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }

            return services;
        }

        // PUT: api/Service/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServices(int id, Service services)
        {
            if (id != services.id)
            {
                return BadRequest();
            }

            _context.Entry(services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
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

        // POST: api/Service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostServices(Service services)
        {
          if (_context.Service == null)
          {
              return Problem("Entity set 'Context.Service'  is null.");
          }
            _context.Service.Add(services);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServices", new { id = services.id }, services);
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            if (_context.Service == null)
            {
                return NotFound();
            }
            var services = await _context.Service.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            _context.Service.Remove(services);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicesExists(int id)
        {
            return (_context.Service?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
