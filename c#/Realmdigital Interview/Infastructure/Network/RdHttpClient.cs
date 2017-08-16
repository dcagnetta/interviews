using System.Net.Http;

namespace Realmdigital_Interview.Infastructure.Network
{
    /// <summary>
    /// Singleton instance of HttpClient
    /// <seealso cref="https://stackoverflow.com/questions/11178220/is-httpclient-safe-to-use-concurrently"/>
    /// </summary>
    public class RdHttpClient
    {
        // singleton instance of HttpClient
        private static HttpClient _httpClient;

        private static readonly object Lock = new object();

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public static HttpClient Default
        {
            get
            {
                if ( _httpClient == null )
                {
                    lock ( Lock )
                    {
                        if ( _httpClient == null )
                        {
                            _httpClient = new HttpClient();
                        }
                    }
                }

                return _httpClient;
            }
        }

        private RdHttpClient()
        {
        }
    }
}