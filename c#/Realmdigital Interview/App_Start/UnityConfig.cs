using Microsoft.Practices.Unity;
using System.Web.Http;
using Realmdigital_Interview.Infastructure.Network;
using Realmdigital_Interview.Services;
using Unity.WebApi;

namespace Retiremate_Integration_Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<INetworkClient, NetworkClient>( new PerThreadLifetimeManager() );
            container.RegisterType<IProductService, ProductService>( new PerThreadLifetimeManager() );

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver( container );
        }
    }
}