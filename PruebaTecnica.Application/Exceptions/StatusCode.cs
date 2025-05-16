namespace PruebaTecnica.Application.Exceptions
{
    public class StatusCode
    {
        public const int Status400BadRequest = 400;
        public const string Status400BadRequestType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";

        public const int Status404NotFound = 404;
        public const string Status404NotFoundType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";

        public const int Status405NotAllowed = 405;
        public const string Status405NotAllowedType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5";

        public const int Status422UnprocessableEntity = 422;
        public const string Status422UnprocessableEntityType = "https://datatracker.ietf.org/doc/html/rfc4918#section-11.2";

        public const int Status500InternalServerError = 500;
        public const string Status500InternalServerErrorType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";

        public const int Status501NotImplemented = 501;
        public const string Status501NotImplementedType = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2";
    }
}
