using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Models;

namespace Realmdigital_Interview.Tests.Network
{
    [TestClass]
    public class NetworkClientTests
    {
        [TestMethod]
        public void Should_Have_InternalServerError_When_Request_Is_InValid()
        {
            // Arrange
            var client = new NetworkClient();
            string bogusWebUrl = "Httx://sdsd2323sdsd.232";

            // Act
            var result = client.PostAsync<ProductReponse>(bogusWebUrl, null).Result;

            // Assert
            Assert.IsTrue( result.StatusCode == HttpStatusCode.InternalServerError );
        }


    }
}
