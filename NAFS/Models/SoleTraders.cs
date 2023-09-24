using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NAFS.Models
{
    public class SoleTraders
    {
        public int id { get; set; }

        [DisplayName("Sole Trader Name")]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }

        [DisplayName("Sole Trader Address")]
        [StringLength(100, MinimumLength = 5)]
        public string? Address { get; set; }

        [DisplayName("Sole Trader Date Of Birth")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DOB { get; set; }

        public string? NI { get; set; }

        [Display(Name = "Contact Number")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? ContactNumber { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid UTR Format")]
        public string? UTR { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;

    }
}
