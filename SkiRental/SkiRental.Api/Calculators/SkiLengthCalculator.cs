using SkiRental.Api.Dtos;

namespace SkiRental.Api.Calculators
{
    public class SkiLengthCalculator : ISkiLengthCalculator
    {
        private const int _maxAvalebleClassicLength = 207;

        public SkiResponseDto CalculateLength(int height, int age, CrossCountrySkiType type)
        {
            int minCompetitionLength = 0;
            int minLength = 0;
            int maxLength = 0;

            if (height >= _maxAvalebleClassicLength - 20 && type == CrossCountrySkiType.Classic)
            {
                minLength = _maxAvalebleClassicLength;
                maxLength = _maxAvalebleClassicLength;
            }
            else if (age <= 4)
            {
                minLength = height;
                maxLength = height;
            }
            else if (age >= 5 && age <= 8)
            {
                minLength = height + 10;
                maxLength = height + 20;
            }
            else if (age > 8 && type == CrossCountrySkiType.Classic)
            {
                minLength = height + 20;
                maxLength = height + 20;
            }
            else if (age > 8 && type == CrossCountrySkiType.Skate)
            {
                minLength = height + 10;
                maxLength = height + 15;
            }

            if (type == CrossCountrySkiType.Skate)
                minCompetitionLength = height - 10;

            return new SkiResponseDto { MinLength = minLength, MaxLength = maxLength, MinCompetitionLength = minCompetitionLength };
        }
    }
}