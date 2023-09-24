using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NAFS.Models
{
    public class LtdCompanies
    {
        public int id { get; set; }

        [DisplayName("Company Name")]
        [StringLength(100, MinimumLength = 2)]
        public string? CompanyName { get; set; }

        [DisplayName("Company Number")]
        //[RegularExpression(@"^(\d{8})$", ErrorMessage = "Invalid Company Number Format")]
        public string? CompanyNumber { get; set; }

        [DisplayName("Company Address")]
        [StringLength(100, MinimumLength = 2)]
        public string? CompanyAddress { get; set; }

        [DisplayName("Director Name")]
        [StringLength(100, MinimumLength = 2)]
        public string? DirectorName { get; set; }

        [Display(Name = "Company Contact")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid company number")]
        public string? CompanyContact { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? CompanyEmail { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;

    }
}
