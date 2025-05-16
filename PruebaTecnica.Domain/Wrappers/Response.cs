using System.Text.Json.Serialization;

namespace PruebaTecnica.Domain.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; private set; } = default!; 
    }
}
