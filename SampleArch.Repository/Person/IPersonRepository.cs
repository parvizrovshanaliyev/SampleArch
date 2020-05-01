using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Repository.Abstracts;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long id);
    }


    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Person> GetAll()
        {
            return DbSet
                .Include(x => x.Country)
                .AsEnumerable();
        }


        public Person GetById(long id)
        {
            return DbSet
                .Include(x => x.Country)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
