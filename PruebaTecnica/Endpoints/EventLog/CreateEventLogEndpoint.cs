using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PruebaTecnica.Application.Features.EventsLog.V1.Commands;
using PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
using System.Threading.Tasks;

namespace PruebaTecnica.Endpoints.EventLog;

public class CreateEventLogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/create-event-log", CreateEventLog)
            .WithTags("EventLog");
    }

    public async Task<IResult> CreateEventLog(HttpContext httpContext, [FromServices] IMediator mediator, [FromBody] CreateEventLogRequest request)
    {
        var result = await mediator.Send(new CreateEventLogCommand
        (
            description: request.Description,
            ipClient: httpContext.Connection.RemoteIpAddress?.ToString() ?? "No se pudo obtener la ip"
        ));

        return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
    }
}
