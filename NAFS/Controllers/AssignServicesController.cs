using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFS.DTO;
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
        public async Task<ActionResult<IEnumerable<AssignServicesDto>>> GetAssignServices()
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }

            var assignServices = await _context.AssignServices.ToListAsync();
            List<AssignServicesDto> lstAssignServices = new List<AssignServicesDto>();

            foreach (var item in assignServices)
            {
                AssignServicesDto objAssignServices = new AssignServicesDto();
                objAssignServices.id = item.id;
                objAssignServices.isLtdCompany = item.isLtdCompany;
                objAssignServices.LtdCompaniesID = item.LtdCompaniesID;
                objAssignServices.SoleTradersID = item.SoleTradersID;
                objAssignServices.Name = item.SoleTradersID == 0 ? _context.LtdCompanies.Where(x => x.id == item.LtdCompaniesID).Select(x => x.CompanyName).FirstOrDefault() : _context.SoleTraders.Where(x => x.id == item.SoleTradersID).Select(x => x.Name).FirstOrDefault();
                objAssignServices.Email = item.SoleTradersID == 0 ? _context.LtdCompanies.Where(x => x.id == item.LtdCompaniesID).Select(x => x.CompanyEmail).FirstOrDefault() : _context.SoleTraders.Where(x => x.id == item.SoleTradersID).Select(x => x.Email).FirstOrDefault();
                objAssignServices.ServiceID = item.ServiceID;
                objAssignServices.ServiceName = item.ServiceID == 0 ? "" : _context.Service.Where(x => x.id == item.ServiceID).Select(x => x.ServiceName).FirstOrDefault();
                objAssignServices.Frequency = item.Frequency;
                objAssignServices.ScheduledDate = item.ScheduledDate;
                objAssignServices.isCompleted = item.isCompleted;
                objAssignServices.StartDate = item.StartDate;
                objAssignServices.SpecialRequest = item.SpecialRequest;
                objAssignServices.SysDate = item.SysDate;

                lstAssignServices.Add(objAssignServices);
            }

            return lstAssignServices;
        }

        // GET: api/AssignServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignServicesDto>> GetAssignServices(int id)
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }
            var assignServices = await _context.AssignServices.FindAsync(id);

            AssignServicesDto objAssignServices = new AssignServicesDto();
            objAssignServices.id = assignServices.id;
            objAssignServices.isLtdCompany = assignServices.isLtdCompany;
            objAssignServices.LtdCompaniesID = assignServices.LtdCompaniesID;
            objAssignServices.SoleTradersID = assignServices.SoleTradersID;
            objAssignServices.Name = assignServices.SoleTradersID == 0 ? _context.LtdCompanies.Where(x => x.id == assignServices.LtdCompaniesID).Select(x => x.CompanyName).FirstOrDefault() : _context.SoleTraders.Where(x => x.id == assignServices.SoleTradersID).Select(x => x.Name).FirstOrDefault();
            objAssignServices.ServiceID = assignServices.ServiceID;
            objAssignServices.ServiceName = assignServices.ServiceID == 0 ? "" : _context.Service.Where(x => x.id == assignServices.ServiceID).Select(x => x.ServiceName).FirstOrDefault();
            objAssignServices.Frequency = assignServices.Frequency;
            objAssignServices.ScheduledDate = assignServices.ScheduledDate;
            objAssignServices.isCompleted = assignServices.isCompleted;
            objAssignServices.StartDate = assignServices.StartDate;
            objAssignServices.SpecialRequest = assignServices.SpecialRequest;
            objAssignServices.SysDate = assignServices.SysDate;


            return objAssignServices;
        }



        // GET: api/AssignServices/5
        [HttpGet("ScheduledDate")]
        public async Task<ActionResult<IEnumerable<AssignServicesDto>>> GetAssignServicesByDate(string fromDate, string toDate)
        {
            if (_context.AssignServices == null)
            {
                return NotFound();
            }


            DateTime fromDatee = DateTime.Parse(fromDate);
            DateTime toDatee = DateTime.Parse(toDate);
            var assignServices = await _context.AssignServices.Where(x => x.ScheduledDate >= fromDatee && x.ScheduledDate <= toDatee).ToListAsync();
            if (assignServices == null)
            {
                return NotFound();
            }

            List<AssignServicesDto> lstAssignServices = new List<AssignServicesDto>();

            foreach (var item in assignServices)
            {
                AssignServicesDto objAssignServices = new AssignServicesDto();
                objAssignServices.id = item.id;
                objAssignServices.isLtdCompany = item.isLtdCompany;
                objAssignServices.LtdCompaniesID = item.LtdCompaniesID;
                objAssignServices.SoleTradersID = item.SoleTradersID;
                objAssignServices.Name = item.SoleTradersID == 0 ? _context.LtdCompanies.Where(x => x.id == item.LtdCompaniesID).Select(x => x.CompanyName).FirstOrDefault() : _context.SoleTraders.Where(x => x.id == item.SoleTradersID).Select(x => x.Name).FirstOrDefault();
                objAssignServices.ServiceID = item.ServiceID;
                objAssignServices.ServiceName = item.ServiceID == 0 ? "" : _context.Service.Where(x => x.id == item.ServiceID).Select(x => x.ServiceName).FirstOrDefault();
                objAssignServices.Frequency = item.Frequency;
                objAssignServices.ScheduledDate = item.ScheduledDate;
                objAssignServices.isCompleted = item.isCompleted;
                objAssignServices.StartDate = item.StartDate;
                objAssignServices.SpecialRequest = item.SpecialRequest;
                objAssignServices.SysDate = item.SysDate;

                lstAssignServices.Add(objAssignServices);
            }

            return lstAssignServices;
        }

        // PUT: api/AssignServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignServices(int id, AssignServices assignServices)
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


        // Post: api/AssignServices/SendEmail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SendEmail")]
        public async Task SendEmail(string subject, string toEmail, string userName, string message)
        {
            try
            {
                await emailSender.SendEmail(subject, toEmail, userName, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/AssignServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignServicesDto>> PostAssignServices(AssignServicesDto assignServices)
        {
            if (_context.AssignServices == null)
            {
                return Problem("Entity set 'Context.AssignServices'  is null.");
            }

            AssignServices objAssignServices = new AssignServices();
            
            if (assignServices.Frequency == "Weekly")
            {
                for(int i = 0 ;i< 52; i++)
                {
                    objAssignServices.id = assignServices.id;
                    objAssignServices.isLtdCompany = assignServices.isLtdCompany;
                    objAssignServices.LtdCompaniesID = assignServices.LtdCompaniesID;
                    objAssignServices.SoleTradersID = assignServices.SoleTradersID;
                    objAssignServices.ServiceID = assignServices.ServiceID;
                    objAssignServices.Frequency = assignServices.Frequency;
                    objAssignServices.ScheduledDate = assignServices.ScheduledDate.AddDays(7*i);
                    objAssignServices.isCompleted = assignServices.isCompleted;
                    objAssignServices.StartDate = assignServices.StartDate;
                    objAssignServices.SpecialRequest = assignServices.SpecialRequest;
                    objAssignServices.SysDate = assignServices.SysDate;
                    _context.AssignServices.Add(objAssignServices);
                    await _context.SaveChangesAsync();
                }
            }
            else if (assignServices.Frequency == "Monthly")
            {
                for (int i = 0; i < 12; i++)
                {
                    objAssignServices.id = assignServices.id;
                    objAssignServices.isLtdCompany = assignServices.isLtdCompany;
                    objAssignServices.LtdCompaniesID = assignServices.LtdCompaniesID;
                    objAssignServices.SoleTradersID = assignServices.SoleTradersID;
                    objAssignServices.ServiceID = assignServices.ServiceID;
                    objAssignServices.Frequency = assignServices.Frequency;
                    objAssignServices.ScheduledDate = assignServices.ScheduledDate.AddMonths(1 * i);
                    objAssignServices.isCompleted = assignServices.isCompleted;
                    objAssignServices.StartDate = assignServices.StartDate;
                    objAssignServices.SpecialRequest = assignServices.SpecialRequest;
                    objAssignServices.SysDate = assignServices.SysDate;
                    _context.AssignServices.Add(objAssignServices);
                    await _context.SaveChangesAsync();
                }
            }
            else if (assignServices.Frequency == "Quartely")
            {
                for (int i = 0; i < 4; i++)
                {
                    objAssignServices.id = assignServices.id;
                    objAssignServices.isLtdCompany = assignServices.isLtdCompany;
                    objAssignServices.LtdCompaniesID = assignServices.LtdCompaniesID;
                    objAssignServices.SoleTradersID = assignServices.SoleTradersID;
                    objAssignServices.ServiceID = assignServices.ServiceID;
                    objAssignServices.Frequency = assignServices.Frequency;
                    objAssignServices.ScheduledDate = assignServices.ScheduledDate.AddMonths(3 * i);
                    objAssignServices.isCompleted = assignServices.isCompleted;
                    objAssignServices.StartDate = assignServices.StartDate;
                    objAssignServices.SpecialRequest = assignServices.SpecialRequest;
                    objAssignServices.SysDate = assignServices.SysDate;
                    _context.AssignServices.Add(objAssignServices);
                    await _context.SaveChangesAsync();
                }
            }
            else if (assignServices.Frequency == "Yearly")
            {
                objAssignServices.id = assignServices.id;
                objAssignServices.isLtdCompany = assignServices.isLtdCompany;
                objAssignServices.LtdCompaniesID = assignServices.LtdCompaniesID;
                objAssignServices.SoleTradersID = assignServices.SoleTradersID;
                objAssignServices.ServiceID = assignServices.ServiceID;
                objAssignServices.Frequency = assignServices.Frequency;
                objAssignServices.ScheduledDate = assignServices.ScheduledDate;
                objAssignServices.isCompleted = assignServices.isCompleted;
                objAssignServices.StartDate = assignServices.StartDate;
                objAssignServices.SpecialRequest = assignServices.SpecialRequest;
                objAssignServices.SysDate = assignServices.SysDate;
                _context.AssignServices.Add(objAssignServices);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetAssignServices", new { id = objAssignServices.id }, objAssignServices);
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
