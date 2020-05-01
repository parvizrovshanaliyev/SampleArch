using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;

namespace SampleArch.Test.Context
{
    public class SampleArchDbContextTest : DbContext
    {
        public SampleArchDbContextTest()
        {
            
        }
        public SampleArchDbContextTest(DbContextOptions<SampleArchDbContextTest> options):base(options)
        {
            
        }



        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }

        #endregion

        #region Overrides of DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS; Database=SampleArchDbContextTest; Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion
    }
}
