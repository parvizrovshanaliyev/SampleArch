using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArch.Repository;
using SampleArch.Test.Context;

namespace SampleArch.Test.Repositories
{
    public class CountryRepositoryTest
    {
        private SampleArchDbContextTest _context;
        private CountryRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _context = new SampleArchDbContextTest();
            _repository = new CountryRepository(_context);
        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act
            var result = _repository.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }
    }
}
