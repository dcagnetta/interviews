using System.Collections.Generic;
using System.Linq;
using Realmdigital_Interview.Models;

namespace Realmdigital_Interview.Utilities.ExtensionMethods
{
    /// <summary>
    /// Extension Method Helpers
    /// </summary>
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Creates the specified product model from the product response.
        /// </summary>
        /// <param name="productReponses">The product response.</param>
        /// <returns></returns>
        public static List<ProductModel> ToModel( this List<ProductReponse> productReponses )
        {
            var model = new List<ProductModel>();

            if ( productReponses == null )
                return model;

            foreach ( var response in productReponses )
            {
                var prices = new List<PriceModel>();

                foreach ( var price in response.PriceRecords.Where( price => price.CurrencyCode.Equals( "ZAR" ) ) )
                {
                    prices.Add( new PriceModel
                    {
                        Price = price.SellingPrice,
                        Currency = price.CurrencyCode
                    } );
                }

                model.Add( new ProductModel
                {
                    Id = response.BarCode,
                    Name = response.ItemName,
                    Prices = prices
                } );
            }

            return model;
        }
    }
}