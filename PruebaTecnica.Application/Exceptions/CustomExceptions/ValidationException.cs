namespace PruebaTecnica.Application.Exceptions.CustomExceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, List<string>> Failures { get; } = default!;


        public ValidationException() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        public ValidationException(string message, string propertyName, string errorMessage) : base(message) =>
            Failures = new()
            {
                [propertyName] = new() { errorMessage }
            };

        public ValidationException(string message, IEnumerable<KeyValuePair<string, string>> failures) : base(message)
        {
            Failures = new();
            foreach (var failure in failures)
            {
                if (Failures.ContainsKey(failure.Key))
                {
                    Failures[failure.Key].Add(failure.Value);
                }
                else
                {
                    Failures.Add(failure.Key, new() { failure.Value });
                }
            }
        }
    }
}
