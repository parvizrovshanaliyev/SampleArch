using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;

namespace SampleArch.Test.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var listCountry = new List<Country>() {
                new Country() { Id = 1, Name = "US" },
                new Country() { Id = 2, Name = "India" },
                new Country() { Id = 3, Name = "Russia" }
            };
            modelBuilder.Entity<Country>().HasData(listCountry);
        }
    }
}
