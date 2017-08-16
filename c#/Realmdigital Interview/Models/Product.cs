using System.Collections.Generic;

namespace Realmdigital_Interview.Models
{
    /// <summary>
    /// Class used to map response object to product
    /// </summary>
    public class ProductReponse
    {
        /// <summary>
        /// Gets or sets the bar code.
        /// </summary>
        /// <value>
        /// The bar code.
        /// </value>
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the price records.
        /// </summary>
        /// <value>
        /// The price records.
        /// </value>
        public List<PriceResponse> PriceRecords { get; set; }
    }

    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PriceModel> Prices { get; set; }
    }
}