using Ardalis.GuardClauses;
using MediatR;
using PruebaTecnica.Domain.Wrappers;

namespace PruebaTecnica.Application.Features.EventsLog.V1.Commands;
public class CreateEventLogCommand : IRequest<Response<string>>
{
    public string Description { get; set; }
    public string IpClient { get; set; }

    public CreateEventLogCommand(string description, string ipClient)
    {
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
        IpClient = Guard.Against.NullOrEmpty(ipClient, nameof(ipClient));
    }
}
