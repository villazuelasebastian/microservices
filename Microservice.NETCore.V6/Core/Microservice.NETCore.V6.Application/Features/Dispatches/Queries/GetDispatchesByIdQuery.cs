using MediatR;
using Microservice.NETCore.V6.Domain.Entities;

namespace Microservice.NETCore.V6.Application.Features.Dispatches.Queries
{
    public class GetDispatchesByIdQuery : IRequest<Dispatch>
    {
        public GetDispatchesByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}