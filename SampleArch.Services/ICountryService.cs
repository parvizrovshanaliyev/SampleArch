using SampleArch.Model;
using SampleArch.Repository;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Services
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int id);
    }

    public class CountryService : EntityService<Country>, ICountryService
    {
        public IUnitOfWork UnitOfWork { get; }
        private readonly ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork,
            ICountryRepository countryRepository) : base(unitOfWork, countryRepository)
        {
            UnitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }


        public Country GetById(int id)
        {
            return _countryRepository.GetById(id);
        }



    }
}