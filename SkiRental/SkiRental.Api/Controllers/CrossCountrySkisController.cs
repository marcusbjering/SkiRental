using SkiRental.Api;
using SkiRental.Api.Calculators;
using SkiRental.Api.Validators;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace SkiRentalApi.Web.Controllers
{
    [RoutePrefix("crosscountryskis")]
    public class CrossCountrySkisController : ApiController
    {
        private readonly IValidationHelper _validator;
        private readonly ISkiLengthCalculator _calculator;

        public CrossCountrySkisController(IValidationHelper validationHelper, ISkiLengthCalculator calculator)
        {
            _validator = validationHelper;
            _calculator = calculator;
        }

        [HttpGet]
        [Route("calculateLength")]
        public IHttpActionResult GetSkiLength([FromUri] int height, [FromUri] int age, [FromUri] CrossCountrySkiType type)
        {
            var validatonResult = _validator.ValidateRequest(height, age, type);
            if (validatonResult.Errors.Any())
            {
                return Content(HttpStatusCode.BadRequest, validatonResult);
            }

            var dto = _calculator.CalculateLength(height, age, type);

            return Ok(dto);
        }
    }
}
