using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiRental.Api.Calculators;

namespace SkiRental.Api.Tests.Unit.CalculatorTests
{
    //Barn 0-4 år: kroppslängd + 0 cm.
    //Barn 5-8 år: kroppslängd + 10 till 20 cm.
    //Klassisk: kroppslängd + 20cm.Klassiska skidor tillverkas bara till längder upp till 207cm.
    //Fristil: kroppslängd + 10 till 15 cm.Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.
    [TestClass]
    public class SkiLengthCalculatorTest
    {
        private SkiLengthCalculator _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new SkiLengthCalculator();
        }


        //Klassisk: kroppslängd + 20cm.
        [TestMethod]
        public void CalculateLength_GivenHeight180Age28TypeClassic_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(180, 28, CrossCountrySkiType.Classic);

            Assert.AreEqual(200, responseDto.MinLength);
            Assert.AreEqual(200, responseDto.MaxLength);
            Assert.AreEqual(0, responseDto.MinCompetitionLength);
        }

        //Klassisk: kroppslängd + 20cm.Klassiska skidor tillverkas bara till längder upp till 207cm.
        [TestMethod]
        public void CalculateLength_GivenHeight200Age28TypeClassic_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(200, 28, CrossCountrySkiType.Classic);

            Assert.AreEqual(207, responseDto.MinLength);
            Assert.AreEqual(207, responseDto.MaxLength);
            Assert.AreEqual(0, responseDto.MinCompetitionLength);
        }

        //Barn 5-8 år: kroppslängd + 10 till 20 cm.
        [TestMethod]
        public void CalculateLength_GivenHeight100Age6TypeClassic_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(100, 6, CrossCountrySkiType.Classic);

            Assert.AreEqual(110, responseDto.MinLength);
            Assert.AreEqual(120, responseDto.MaxLength);
            Assert.AreEqual(0, responseDto.MinCompetitionLength);
        }

        //Barn 0-4 år: kroppslängd + 0 cm.
        [TestMethod]
        public void CalculateLength_GivenHeight100Age3TypeClassic_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(100, 3, CrossCountrySkiType.Classic);

            Assert.AreEqual(100, responseDto.MinLength);
            Assert.AreEqual(100, responseDto.MaxLength);
            Assert.AreEqual(0, responseDto.MinCompetitionLength);
        }

        //Fristil: kroppslängd + 10 till 15 cm. Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.
        [TestMethod]
        public void CalculateLength_GivenHeight180Age28TypeSkate_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(180, 28, CrossCountrySkiType.Skate);

            Assert.AreEqual(190, responseDto.MinLength);
            Assert.AreEqual(195, responseDto.MaxLength);
            Assert.AreEqual(170, responseDto.MinCompetitionLength);
        }

        //Barn 5-8 år: kroppslängd + 10 till 20 cm.
        //Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.
        [TestMethod]
        public void CalculateLength_GivenHeight100Age6TypeSkate_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(100, 6, CrossCountrySkiType.Skate);

            Assert.AreEqual(110, responseDto.MinLength);
            Assert.AreEqual(120, responseDto.MaxLength);
            Assert.AreEqual(90, responseDto.MinCompetitionLength);
        }

        //Barn 0-4 år: kroppslängd + 0 cm.
        //Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.
        [TestMethod]
        public void CalculateLength_GivenHeight100Age3TypeSkate_ReturnsCorrectDto()
        {
            var responseDto = _sut.CalculateLength(100, 3, CrossCountrySkiType.Skate);

            Assert.AreEqual(100, responseDto.MinLength);
            Assert.AreEqual(100, responseDto.MaxLength);
            Assert.AreEqual(90, responseDto.MinCompetitionLength);
        }
    }
}
