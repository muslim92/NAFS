using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFS.Models;
using NAFS.Services.SendGridEmail;

namespace NAFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignServicesController : ControllerBase
    {
        private readonly Context _context;

        EmailSender emailSender = new EmailSender();

        public AssignServicesController(Context context)
        {
            _context = context;
        }

        // GET: api/AssignServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignServices>>> GetAssignServices()
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }
            await emailSender.SendEmail("test email", "abbas721412@gmail.com", "Muslim Abbas", "test email ha bhai. no worries");
            return await _context.AssignServices.ToListAsync();

        }

        // GET: api/AssignServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignServices>> GetAssignServices(int id)
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }
            var assignServices = await _context.AssignServices.FindAsync(id);

            if (assignServices == null)
            {
                return NotFound();
            }

            return assignServices;
        }

        // PUT: api/AssignServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignServices(int id, AssignServices assignServices)
        {
            if (id != assignServices.id)
            {
                return BadRequest();
            }

            _context.Entry(assignServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignServicesExists(id))
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

        // POST: api/AssignServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignServices>> PostAssignServices(AssignServices assignServices)
        {
            if (_context.AssignServices == null)
            {
                return Problem("Entity set 'Context.AssignServices'  is null.");
            }
            _context.AssignServices.Add(assignServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignServices", new { id = assignServices.id }, assignServices);
        }

        // DELETE: api/AssignServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignServices(int id)
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }
            var assignServices = await _context.AssignServices.FindAsync(id);
            if (assignServices == null)
            {
                return NotFound();
            }

            _context.AssignServices.Remove(assignServices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignServicesExists(int id)
        {
            return (_context.AssignServices?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
