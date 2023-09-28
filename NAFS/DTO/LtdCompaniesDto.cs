using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NAFS.DTO
{
    public class LtdCompaniesDto
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyNumber { get; set; }
        public string? CompanyAddress { get; set; }
        public string? DirectorName { get; set; }
        public string? CompanyContact { get; set; }
        public string? CompanyEmail { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;
    }
}
