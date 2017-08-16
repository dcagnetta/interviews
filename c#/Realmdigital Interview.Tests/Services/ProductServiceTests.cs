using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Services;
using Realmdigital_Interview.Utilities.Enums;

namespace Realmdigital_Interview.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        public IProductService Service { get; set; }


        [TestMethod]
        public void Should_Return_List_Products_When_Search_IsValid()
        {
            // Arrange
            string productId = "ProductId";
            Service = new ProductService( new NetworkClient() );

            // Act
            var result = Service.GetProduct( productId, SearchType.Id ).Result;

            // Assert
            Assert.IsNull( result.Error );
            Assert.IsTrue( result.Value.Any() );
        }

        [TestMethod]
        public void Should_Have_InternalServerError_When_Web_Url_Is_InValid()
        {
            // Arrange
            string productId = "ProductId";
            string bogusWebUrl = "Httx://sdsd2323sdsd.232";
            Service = new ProductService( new NetworkClient(), bogusWebUrl );

            // Act
            var result = Service.GetProduct( productId, SearchType.Id ).Result;

            // Assert
            Assert.IsTrue( result.StatusCode == HttpStatusCode.InternalServerError );
        }
    }
}
