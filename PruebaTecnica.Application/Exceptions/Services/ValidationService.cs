using PruebaTecnica.Application.Exceptions.Interfaces;

namespace PruebaTecnica.Application.Exceptions.Services
{
    public class ValidationService<ValidationType> : IValidationService<ValidationType>
    {
        public IEnumerable<ICustomValidator<ValidationType>> _validators;

        public ValidationService(IEnumerable<ICustomValidator<ValidationType>> validators) => _validators = validators;

        public async ValueTask ExecuteValidationGuard(ValidationType instanceToValidate, bool stopOnFirstValidationError = true)
        {
            List<KeyValuePair<string, string>> failures = new();
            bool contineValidation = true;

            IEnumerator<ICustomValidator<ValidationType>> enumerators = _validators.GetEnumerator();

            while (enumerators.MoveNext() && contineValidation)
            {
                bool isValid = await enumerators.Current.Validate(instanceToValidate);
                if (!isValid)
                {
                    failures.AddRange(enumerators.Current.Failures);
                    contineValidation = !stopOnFirstValidationError;
                }
            }

            if (failures.Any())
            {
                throw new CustomExceptions.ValidationException("Error de validación.", failures);
            }
        }
    }
}
