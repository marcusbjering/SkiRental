using SkiRental.Api.Dtos;

namespace SkiRental.Api.Calculators
{
    public interface ISkiLengthCalculator
    {
        SkiResponseDto CalculateLength(int height, int age, CrossCountrySkiType type);
    }
}