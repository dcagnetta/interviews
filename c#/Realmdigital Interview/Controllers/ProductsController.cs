using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Services;
using Realmdigital_Interview.Utilities.Enums;
using Realmdigital_Interview.Utilities.ExtensionMethods;

namespace Realmdigital_Interview.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController( IProductService service )
        {
            _service = service;
        }

        // GET api/products/product/productId
        /// <summary>
        /// Gets the name of the products by product id.
        /// </summary>
        /// <param name="productId">Name of the product.</param>
        /// <returns></returns>
        [HttpGet]
        [Route( "api/products/product/{productId}" )]
        public async Task<ProductModel> GetProductById( string productId )
        {
           var reponseObject = await _service.GetProduct( productId, SearchType.Id );

            if ( reponseObject.StatusCode != HttpStatusCode.OK ) return null;

            var model = reponseObject.Value.ToModel();

            return model.FirstOrDefault();
        }

        // GET api/products/search/productName
        /// <summary>
        /// Gets the name of the products by product name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        [HttpGet]
        [Route( "api/products/search/{productName}" )]
        public async Task<List<ProductModel>> GetProductsByName( string productName )
        {
            var reponseObject = await _service.GetProduct( productName, SearchType.Name );

            if ( reponseObject.StatusCode != HttpStatusCode.OK ) return null;

            var model = reponseObject.Value.ToModel();

            return model;
        }
    }


}