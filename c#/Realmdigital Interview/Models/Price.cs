namespace Realmdigital_Interview.Models
{
    /// <summary>
    /// Class used to map response object to price
    /// </summary>
    public class PriceResponse
    {
        /// <summary>
        /// Gets or sets the selling price.
        /// </summary>
        /// <value>
        /// The selling price.
        /// </value>
        public string SellingPrice { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }
    }

    public class PriceModel
    {
        public string Price { get; set; }
        public string Currency { get; set; }
    }
}