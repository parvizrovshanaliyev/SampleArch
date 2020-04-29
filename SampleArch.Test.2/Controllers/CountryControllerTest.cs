//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SampleArch.Services;

//namespace SampleArch.Test._2.Controllers
//{
//    [TestClass]
//    public class CountryControllerTest
//    {
//        private Mock<ICountryService> _countryServiceMock;
//        CountryController _objController;
//        List<Country> _listCountry;

//        [TestInitialize]
//        public void Initialize()
//        {

//            _countryServiceMock = new Mock<ICountryService>();
//            _objController = new CountryController(_countryServiceMock.Object);
//            _listCountry = new List<Country>() {
//           new Country() { Id = 1, Name = "US" },
//           new Country() { Id = 2, Name = "India" },
//           new Country() { Id = 3, Name = "Russia" }
//          };
//        }

//        [TestMethod]
//        public void Country_Get_All()
//        {
//            //Arrange
//            _countryServiceMock.Setup(x => x.GetAll()).Returns(_listCountry);

//            //Act
//            var result = (((Microsoft.AspNetCore.Mvc.ViewResult)_objController.Index())?.Model) as List<Country>;

//            //Assert
//            if (result == null) return;
//            Assert.AreEqual(result.Count, 3);
//            Assert.AreEqual("US", result[0].Name);
//            Assert.AreEqual("India", result[1].Name);
//            Assert.AreEqual("Russia", result[2].Name);
//        }

//        [TestMethod]
//        public void Valid_Country_Create()
//        {
//            //Arrange
//            Country country = new Country() { Name = "test1" };

//            //Act
//            var result = (RedirectToRouteResult)_objController.Create(country);

//            //Assert 
//            _countryServiceMock.Verify(m => m.Create(country), Times.Once);
//            Assert.AreEqual("Index", result.RouteValues["action"]);

//        }

//        [TestMethod]
//        public void Invalid_Country_Create()
//        {
//            // Arrange
//            Country country = new Country() { Name = "" };
//            _objController.ModelState.AddModelError("Error", "Something went wrong");

//            //Act
//            var result = (ViewResult)_objController.Create(country);

//            //Assert
//            _countryServiceMock.Verify(m => m.Create(country), Times.Never);
//            Assert.AreEqual("", result.ViewName);
//        }
//    }
//}
