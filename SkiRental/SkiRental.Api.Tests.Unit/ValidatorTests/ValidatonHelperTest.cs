using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiRental.Api.Validators;
using System.Linq;

namespace SkiRental.Api.Tests.Unit.ValidatorTests
{
    [TestClass]
    public class ValidatonHelperTest
    {
        private ValidationHelper _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new ValidationHelper();
        }

        [TestMethod]
        public void ValidateRequest_GivenHeight0_ReturnsValidationResultWithError()
        {
            var result = _sut.ValidateRequest(0, 10, CrossCountrySkiType.Classic);
            Assert.AreEqual("Height cannot be 0 or below", result.Errors.FirstOrDefault());
        }

        [TestMethod]
        public void ValidateRequest_GivenAge0_ReturnsValidationResultWithError()
        {
            var result = _sut.ValidateRequest(100, 0, CrossCountrySkiType.Classic);
            Assert.AreEqual("Age cannot be 0 or below", result.Errors.FirstOrDefault());
        }
    }
}
