using Microsoft.AspNetCore.Identity.EntityFrameworkCore; //  Needed for Identity
using Microsoft.EntityFrameworkCore;
using CyberCrimeComplaintPortal.Models;

namespace CyberCrimeComplaintPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext //  Use IdentityDbContext instead of DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Complaint> Complaints { get; set; } //  Your existing Complaint table
    }
}
