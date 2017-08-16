using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Realmdigital_Interview.Infastructure.Network
{
    public class NetworkClient : INetworkClient
    {
        public async Task<ServiceResponse<T>> PostAsync<T>( string address, object dto )
        {
            //// post asynchronously
            try
            {
                //// serialize DTO to string
                string json = JsonConvert.SerializeObject( dto );

                StringContent content = new StringContent( json, Encoding.UTF8, "application/json" );

                var response = await RdHttpClient.Default.PostAsync( address, content );

                return await GetResponse<T>( response );
            }
            catch ( Exception ex )
            {
                return new ServiceResponse<T>( HttpStatusCode.InternalServerError, ex );
            }
        }

        #region Private Methods

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        private static async Task<ServiceResponse<T>> GetResponse<T>( HttpResponseMessage response )
        {
            var serviceResponse = new ServiceResponse<T>( response.StatusCode );

            if ( !response.IsSuccessStatusCode )
            {
                return serviceResponse;
            }

            try
            {
                //// get response string
                serviceResponse.Content = await response.Content.ReadAsStringAsync();
                //// serialize the response to object
                serviceResponse.Value = JsonConvert.DeserializeObject<T>( serviceResponse.Content );
            }
            catch ( Exception ex )
            {
                serviceResponse.Error = ex;
            }

            return serviceResponse;
        }

        #endregion Private Methods
    }
}