using SkiRentalApi.Web.App_Start;
using System.Web.Http;
using Unity;

namespace SkiRentalApi.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
            config.MapHttpAttributeRoutes();
        }

        private static void RegisterTypes(UnityContainer container)
        {
            //container.RegisterType<>();
        }
    }
}
