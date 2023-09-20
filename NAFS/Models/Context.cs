using Microsoft.EntityFrameworkCore;
using NAFS.Models;

namespace NAFS.Models
{
    public class Context: DbContext
    {
       public Context(DbContextOptions<Context> options): base(options) 
        {
            
        }

        public DbSet<LtdCompanies> LtdCompanies { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<AssignServices> AssignServices{ get; set; }
        public DbSet<SoleTraders> SoleTraders { get; set; } = default!;

    }
}
