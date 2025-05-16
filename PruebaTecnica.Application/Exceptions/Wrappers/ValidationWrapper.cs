using FluentValidation;
using PruebaTecnica.Application.Exceptions.Interfaces;

namespace PruebaTecnica.Application.Exceptions.Wrappers
{
    public abstract class ValidationWrapper<ValidatorType> : AbstractValidator<ValidatorType>, ICustomValidator<ValidatorType>
    {
        public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; } = default!;

        async ValueTask<bool> ICustomValidator<ValidatorType>.Validate(ValidatorType instanceToValidate)
        {
            FluentValidation.Results.ValidationResult validationResult = await ValidateAsync(instanceToValidate);

            if (!validationResult.IsValid)
            {
                Failures = validationResult.Errors
                    .Select(x => new KeyValuePair<string, string>(x.PropertyName, x.ErrorMessage))
                    .ToList();
            }

            return validationResult.IsValid;
        }
    }
}
