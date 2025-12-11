namespace SgiAzure.Application.Common
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        private ValidationResult(bool isValid, string errorMessage = "")
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true);
        }

        public static ValidationResult Fail(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

    }
}
