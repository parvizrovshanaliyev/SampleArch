using SampleArch.Model;
using SampleArch.Repository;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Services
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long id);
    }

    public class PersonService : EntityService<Person>, IPersonService
    {
        public IUnitOfWork UnitOfWork { get; }
        private readonly IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork,
            IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            UnitOfWork = unitOfWork;
            _personRepository = personRepository;
        }


        public Person GetById(long id)
        {
            return _personRepository.GetById(id);
        }
    }
}