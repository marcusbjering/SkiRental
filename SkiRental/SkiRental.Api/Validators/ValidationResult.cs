using System.Collections.Generic;

namespace SkiRental.Api
{
    public interface IValidationResult
    {
        List<string> Errors { get; set; }
        void AddError(string error);
    }

    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}