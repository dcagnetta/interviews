using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Utilities.Enums;

namespace Realmdigital_Interview.Services
{
    public class ProductService : IProductService
    {
        private readonly INetworkClient _networkClient;
        private readonly string _webUrlBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="networkClient">The network client.</param>
        public ProductService( INetworkClient networkClient )
        {
            _networkClient = networkClient;
            _webUrlBase = ConfigurationManager.AppSettings["WebUrlBase"] ?? "http://192.168.0.241/eanlist?type=Web";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="networkClient">The network client.</param>
        /// <param name="webUrlBase">The web URL base.</param>
        public ProductService( INetworkClient networkClient, string webUrlBase ) : this( networkClient )
        {
            _webUrlBase = webUrlBase;
        }

        /// <summary>
        /// Gets the products by search type and return the list of product responses.
        /// </summary>
        /// <param name="searchValue">The product identifier.</param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<ProductReponse>>> GetProduct( string searchValue, SearchType searchType )
        {
            object product;

            switch ( searchType )
            {
                case SearchType.Id:
                    product = new { id = searchValue };
                    break;

                case SearchType.Name:
                    product = new { name = searchValue };
                    break;

                default:
                    throw new ArgumentException( "Invalid Search Type specified." );
            }

            // Post
            return await _networkClient.PostAsync<List<ProductReponse>>( _webUrlBase, product );
        }
    }
}