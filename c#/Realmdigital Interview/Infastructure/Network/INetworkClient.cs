using System.Threading.Tasks;

namespace Realmdigital_Interview.Infastructure.Network
{
    public interface INetworkClient
    {
        /// <summary>
        /// Async POST method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">The address.</param>
        /// <param name="dto">The DTO.</param>
        /// <param name="serializeResponse"></param>
        /// <returns></returns>
        Task<ServiceResponse<T>> PostAsync<T>( string address, object dto );
    }
}