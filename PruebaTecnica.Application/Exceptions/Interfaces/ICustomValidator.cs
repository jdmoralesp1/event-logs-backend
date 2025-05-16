namespace PruebaTecnica.Application.Exceptions.Interfaces
{
    public interface ICustomValidator<InstanceType>
    {
        ValueTask<bool> Validate(InstanceType instanceToValidate);
        IEnumerable<KeyValuePair<string, string>> Failures { get; }
    }
}
