using SkiRental.Api.Calculators;
using SkiRental.Api.Validators;
using SkiRentalApi.Web.App_Start;
using System.Web.Http;
using System.Web.Http.Cors;
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

            var corsAttr = new EnableCorsAttribute("http://localhost:9000", "*", "*");
            config.EnableCors(corsAttr);
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IValidationHelper, ValidationHelper>();
            container.RegisterType<ISkiLengthCalculator, SkiLengthCalculator>();
        }
    }
}
