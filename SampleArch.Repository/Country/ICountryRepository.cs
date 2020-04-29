using System.Linq;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Repository.Abstracts;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }

    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context)
            : base(context)
        {

        }

        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}