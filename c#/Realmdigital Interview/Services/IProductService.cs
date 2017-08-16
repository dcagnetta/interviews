using System.Collections.Generic;
using System.Threading.Tasks;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Utilities.Enums;

namespace Realmdigital_Interview.Services
{
    /// <summary>
    /// Product Service Interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the products by search type and return the list of product responses.
        /// </summary>
        /// <param name="searchValue">The product identifier.</param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<ProductReponse>>> GetProduct( string searchValue, SearchType searchType );
    }
}