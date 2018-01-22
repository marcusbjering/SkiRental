using SkiRental.Api.Calculators;
using SkiRental.Api.Validators;
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
            config.EnableCors();
            config.MapHttpAttributeRoutes();
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IValidationHelper, ValidationHelper>();
            container.RegisterType<ISkiLengthCalculator, SkiLengthCalculator>();
        }
    }
}
