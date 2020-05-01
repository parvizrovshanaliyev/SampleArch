using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleArch.Model;
using SampleArch.ORM;
using SampleArch.Repository;
using SampleArch.Repository.Interfaces;
using SampleArch.Services;

namespace SampleArch.Test.Services
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Country> _listCountry;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new CountryService(_mockUnitWork.Object, _mockRepository.Object);
            _listCountry = new List<Country>() {
                new Country() { Id = 1, Name = "US" },
                new Country() { Id = 2, Name = "India" },
                new Country() { Id = 3, Name = "Russia" }
            };
        }

        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(_listCountry);

            //Act
            List<Country> results = _service.GetAll() as List<Country>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Can_Add_Country()
        {
            //Arrange
            int Id = 1;
            Country country = new Country() { Name = "UK" };
            _mockRepository.Setup(m =>
                m.Add(country))
                .Returns((Country e) =>
            {
                e.Id = Id;
                return e;
            });


            //Act
            _service.Create(country);

            //Assert
            Assert.AreEqual(Id, country.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }

    }
}
