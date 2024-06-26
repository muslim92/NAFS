﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NAFS.Models
{
    public class Service
    {
        public int id { get; set; }

        [DisplayName("Service Name")]
        [StringLength(100, MinimumLength = 2)]
        public string? ServiceName { get; set; }

        //[RegularExpression(@"^(\d{4})$", ErrorMessage = "Invalid Service Code")]
        public string? ServiceCode { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;
    }
}
