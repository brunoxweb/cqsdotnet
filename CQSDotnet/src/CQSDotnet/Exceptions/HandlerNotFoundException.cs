using CQSDotnet.Models;

namespace CQSDotnet.Exceptions
{
    public class ValidationStatusException : Exception
    {
        public ValidationStatusException(ValidationStatus validationStatus)
        {
            this.ValidationStatus = validationStatus ?? new ValidationStatus();
            this.ValidationStatus.IsValid = false;
        }

        public ValidationStatus ValidationStatus { get; }
    }
}