using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.ORM;
using Xunit;

namespace SampleArch.XUnitTest
{
    public class SampleArchDbContextTests
    {
        [Fact]
        public void ShouldBeAbleToAddInMemoryDb()
        {
            var builder = 
                new DbContextOptionsBuilder<SampleArchDbContext>()
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            using var context = new SampleArchDbContext(builder.Options);
            context.People.Add(
                new Person
                {
                    Name = "Parviz",
                    Phone = "0506856915",
                    Address = "Baku",
                    State = "Baku",
                    CountryId = 1
                });
            context.SaveChanges();

            Assert.Equal(1,context.People.Count(p=>
                p.Name=="Parviz"));
        }

        [Fact]
        public void ShouldBeAbleToAddSqlLiteDb()
        {
            var builder =
                new DbContextOptionsBuilder<SampleArchDbContext>()
                    .EnableSensitiveDataLogging()
                    .UseSqlite("DataSource=:memory:");

            using var context = new SampleArchDbContext(builder.Options);

            // Required for SqlLite
            context.Database.OpenConnection();
            context.Database.EnsureCreated();


            context.People.Add(
                new Person
                {
                    Name = "Parviz",
                    Phone = "0506856915",
                    Address = "Baku",
                    State = "Baku",
                    CountryId = 1
                });

            context.SaveChanges();

            Assert.Equal(1, context.People.Count(p =>
                p.Name == "Parviz"));
        }
    }
}
