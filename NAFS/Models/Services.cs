using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NAFS.Models
{
    public class Services
    {
        public int id { get; set; }

        [DisplayName("Service Name")]
        [Required(ErrorMessage = "Service Name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string ServiceName { get; set; }

        //[RegularExpression(@"^(\d{4})$", ErrorMessage = "Invalid Service Code")]
        public string? ServiceCode { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;
    }
}
