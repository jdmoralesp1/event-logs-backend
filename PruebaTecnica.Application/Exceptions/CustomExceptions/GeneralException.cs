namespace PruebaTecnica.Application.Exceptions.CustomExceptions
{
    public class GeneralException : Exception
    {
        public string Detail { get; } = default!;

        public GeneralException() { }

        public GeneralException(string message) : base(message) { }

        public GeneralException(string message, Exception innerException) : base(message, innerException) { }

        public GeneralException(string title, string detail) : base(title) =>
            Detail = detail;
    }
}
