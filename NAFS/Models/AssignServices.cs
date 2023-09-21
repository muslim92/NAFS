using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NAFS.Models
{
    public class AssignServices
    {
        public int id { get; set; }
        public int? LtdCompaniesID { get; set; }
        public int? SoleTradersID { get; set; }

        [Required(ErrorMessage = "Service ID is required")]
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public virtual Services ServiceFK { get; set; }

        [Required(ErrorMessage = "Frequency is required")]
        public string Frequency { get; set; }

        [Required(ErrorMessage = "Scheduled Date is required")]
        public DateTime ScheduledDate { get; set; }
        [Required(ErrorMessage = "Scheduled Service is Completed or Not")]
        public bool isCompleted { get; set; }


        //Optional in case apply for future
        public DateTime? StartDate { get; set; }

        public DateTime? SysDate { get; set; } = DateTime.Now;

    }
}
