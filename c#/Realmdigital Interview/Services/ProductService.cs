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
        private readonly string _webUrlBase = ConfigurationManager.AppSettings["WebUrlBase"];

        public ProductService( INetworkClient networkClient )
        {
            _networkClient = networkClient;
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