namespace SkiRental.Api.Validators
{
    public interface IValidationHelper
    {
        IValidationResult ValidateRequest(int height, int age, CrossCountrySkiType type);
    }
}