namespace NAFS.DTO
{
    public class AssignServicesDto
    {
        public int id { get; set; }
        public bool isLtdCompany { get; set; }
        public int? LtdCompaniesID { get; set; }
        public int? SoleTradersID { get; set; }
        public string? Name { get; set; }
        public int ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? Frequency { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool? isCompleted { get; set; }

        //Optional in case apply for future
        public DateTime? StartDate { get; set; }

        public string? SpecialRequest { get; set; }
        public DateTime? SysDate { get; set; } = DateTime.Now;
    }
}
