using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleArch.Model;
using SampleArch.Services;
using SampleArch.Web.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleArch.Test.Controllers
{
    [TestClass]
    public class CountryControllerTest
    {
        private Mock<ICountryService> _countryServiceMock;
        private CountryController _controller;
        private List<Country> _listCountry;

        [TestInitialize]
        public void Initialize()
        {

            _countryServiceMock = new Mock<ICountryService>();
            _controller = new CountryController(_countryServiceMock.Object);
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
            _countryServiceMock.Setup(x => x.GetAll()).Returns(_listCountry);

            //Act
            var result = (((Microsoft.AspNetCore.Mvc.ViewResult) _controller.Index())?.Model) as List<Country>;

            //Assert
            if (result == null) return;
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Valid_Country_Create()
        {
            //Arrange
            Country c = new Country() { Name = "test1" };

            //Act
            var result = (RedirectToActionResult)_controller.Create(c);
           
            //Assert 
            _countryServiceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Country", result.ControllerName);
        }

        [TestMethod]
        public void Invalid_Country_Create()
        {
            // Arrange
            Country country = new Country() { Name = "" };
            _controller.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)_controller.Create(country);

            //Assert
            _countryServiceMock.Verify(m => m.Create(country), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}
