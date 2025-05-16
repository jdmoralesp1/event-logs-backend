using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
using PruebaTecnica.Application.Features.EventsLog.V1.Queries;
using System.Threading.Tasks;

namespace PruebaTecnica.Endpoints.EventLog;

public class GetAllEventsLogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/get-all-events-log", GetAllEventsLog)
            .WithTags("EventLog");
    }

    public async Task<IResult> GetAllEventsLog([FromServices] ISender mediator, [FromBody] GetAllEventsLogRequest request)
    {
        var result = await mediator.Send(new GetAllEventsLogQuery(
            eventType: request.EventType,
            initialDate: request.InitialDate,
            finalDate: request.FinalDate
        ));

        return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
    }
}
