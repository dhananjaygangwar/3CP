using Microsoft.EntityFrameworkCore;
using CyberCrimeComplaintPortal.Models;

namespace CyberCrimeComplaintPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Complaint> Complaints { get; set; }
    }
}
