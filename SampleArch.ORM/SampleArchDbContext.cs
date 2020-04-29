using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Model.BaseEntities.Interfaces;

namespace SampleArch.ORM
{
    public class SampleArchDbContext : DbContext
    {
        public SampleArchDbContext()
        {
            
        }
        public SampleArchDbContext( DbContextOptions<SampleArchDbContext> options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        #region .:: OnConfiguring ::.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS; Database=SampleArch; Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion OnConfiguring

        //public override int SaveChanges()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity &&
        //                             (x.State == EntityState.Added ||
        //                              x.State == EntityState.Modified));

        //    foreach (var entry in modifiedEntries)
        //    {
        //        if (!(entry.Entity is IAuditableEntity entity)) continue;
        //        var identityName = Thread.CurrentPrincipal.Identity.Name;
        //        var now = DateTime.UtcNow;

        //        if (entry.State == EntityState.Added)
        //        {
        //            entity.CreatedBy = identityName;
        //            entity.CreatedDate = now;
        //        }
        //        else
        //        {
        //            base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //            base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //        }

        //        entity.UpdatedBy = identityName;
        //        entity.UpdatedDate = now;
        //    }

        //    return base.SaveChanges();
        //}
    }
}
