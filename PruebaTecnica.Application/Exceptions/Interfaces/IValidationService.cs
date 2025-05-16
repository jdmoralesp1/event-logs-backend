namespace PruebaTecnica.Application.Exceptions.Interfaces
{
    public interface IValidationService<ValidationType>
    {
        ValueTask ExecuteValidationGuard(ValidationType instanceToValidate, bool stopOnFirstValidationError = true);
    }
}
