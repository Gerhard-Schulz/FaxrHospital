using FaxrHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace FaxrHospital
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<Illnes> Illnes { get; set; }
        public DbSet<Otdelenie> Otdelenie { get; set; }
        public DbSet<IllnesHistory> IllnesHistory { get; set; }

        public ApplicationDbContext() => Database.EnsureCreated();
    }
}
