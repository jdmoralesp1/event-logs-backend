namespace PruebaTecnica.Domain.ValueObjects
{
    public record struct ProblemDetail(int StatusCode,
                                    string Type,
                                    string Title,
                                    string Detail,
                                    Dictionary<string, List<string>> InvalidParams);
}
