using System;
using System.Collections.Generic;
using System.Text;
using SampleArch.Model.BaseEntities.Abstracts;

namespace SampleArch.Model
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
