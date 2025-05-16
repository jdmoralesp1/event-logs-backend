namespace PruebaTecnica.Application.Exceptions.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public IReadOnlyList<string> Entries { get; } = default!;

        public BadRequestException() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string entity, Exception innerException) : base(entity, innerException) { }
    }
}
