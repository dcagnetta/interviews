using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Controllers;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Services;

namespace Realmdigital_Interview.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void Should_Return_List_Products_When_Search_IsValid()
        {
            // Arrange
            var controller = new ProductsController( new ProductService( new NetworkClient() ) );
            string productName = "TestProduct";

            // Act
            var result = controller.GetProductsByName( productName ).Result;

            // Assert
            Assert.IsNotNull( result );
            Assert.IsTrue( result.Any() );

        }

        [TestMethod]
        public void Should_Return_Only_1_Product()
        {
            // Arrange
            var controller = new ProductsController( new ProductService( new NetworkClient() ) );
            string productId = "ProductId";

            // Act
            var result = controller.GetProductById( productId ).Result;

            // Assert
            Assert.IsNotNull( result );
            Assert.AreNotEqual( typeof( List<ProductModel>), result.GetType() );

        }

        [TestMethod]
        public void Should_Return_Only_List_Of_Products()
        {
            // Arrange
            var controller = new ProductsController( new ProductService( new NetworkClient() ) );
            string productName = "ProductName";

            // Act
            var result = controller.GetProductsByName( productName ).Result;

            // Assert
            Assert.IsNotNull( result );
            Assert.AreEqual( typeof( List<ProductModel> ), result.GetType() );

        }

    }
}
