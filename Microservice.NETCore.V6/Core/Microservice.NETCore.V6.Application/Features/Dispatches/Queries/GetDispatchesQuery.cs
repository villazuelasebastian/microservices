using MediatR;
using Microservice.NETCore.V6.Domain.Entities;

namespace Microservice.NETCore.V6.Application.Features.Dispatches.Queries;

public class GetDispatchesQuery : IRequest<IEnumerable<Dispatch>>
{
}