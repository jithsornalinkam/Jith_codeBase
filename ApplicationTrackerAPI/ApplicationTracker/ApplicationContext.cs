using ApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTracker
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasData(new Application
            {
                ID = 1,
                CompanyName = "Alpha",
                Position = "Senior Developer",
                Status = "Progress",
                DateApplied = new DateTime(2025, 01, 25),
            }, new Application
            {
                ID = 2,
                CompanyName = "Beta",
                Position = "Developer",
                Status = "Progress",
                DateApplied = new DateTime(2025, 01, 25),
            }, new Application
            {
                ID = 3,
                CompanyName = "Beta",
                Position = "Developer",
                Status = "Rejected",
                DateApplied = new DateTime(2025, 01, 15),
            }
            );
        }
    }
}
