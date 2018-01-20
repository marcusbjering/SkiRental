namespace SkiRental.Api.Validators
{
    public class ValidationHelper : IValidationHelper
    {
        public IValidationResult ValidateRequest(int height, int age, CrossCountrySkiType type)
        {
            var validationResult = new ValidationResult();

            if (height <= 0)
                validationResult.AddError("Height cannot be 0 or below");
            
            if (age <= 0)
                validationResult.AddError("Age cannot be 0 or below");

            if(!CrossCountrySkiType.IsDefined(typeof(CrossCountrySkiType), type))
                validationResult.AddError("Type is not set");

            return validationResult;
        }
    }
}