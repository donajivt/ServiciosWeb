using Rest.Api.Compras.Controllers;
using Rest.Api.Domain1.Infraestructura;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Rest.Api.Compras
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ArticulosController>();
            container.RegisterType< IRepositorioArticulos, IRepositorioArticulos>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}