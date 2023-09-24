using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NAFS.Models
{
    public class AssignServices
    {
        public int id { get; set; }
        public int? LtdCompaniesID { get; set; }
        public int? SoleTradersID { get; set; }
        public int ServiceID { get; set; }
        public string? Frequency { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool? isCompleted { get; set; }

        //Optional in case apply for future
        public DateTime? StartDate { get; set; }

        public string? SpecialRequest { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;

    }
}
