using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkiRentalApi.Web.Controllers
{
    public class CrossCountrySkisController : ApiController
    {
        //private readonly ICrossCountrySkisRequestValidator

        public IHttpActionResult Get(decimal length, int age, CrossCountrySkiType type)
        {


            return Ok();
        }

        public enum CrossCountrySkiType
        {
            Classic = 1,
            Skate = 2
        }
    }
}
