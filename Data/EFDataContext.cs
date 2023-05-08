using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    public class EntityFrameowrkContext : DbContext
    {
        public DbSet<Computer> Computer { get; set; }

        string dbConnectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa; Password=SQLConnect1";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(dbConnectionString, options => options.EnableRetryOnFailure());
                //base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);

        }
    }
}
