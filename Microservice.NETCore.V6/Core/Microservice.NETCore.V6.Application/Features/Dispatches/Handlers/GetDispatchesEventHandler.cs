using MediatR;
using Microservice.NETCore.V6.Application.Features.Dispatches.Queries;
using Microservice.NETCore.V6.Application.Interfaces.Repositories;
using Microservice.NETCore.V6.Domain.Entities;

namespace Microservice.NETCore.V6.Application.Features.Dispatches.Handlers;

public class GetDispatchesEventHandler : IRequestHandler<GetDispatchesQuery, IEnumerable<Dispatch>>
{
    private readonly IDispatchesRepository _dispatchesRepository;

    public GetDispatchesEventHandler(IDispatchesRepository dispatchesRepository)
        => _dispatchesRepository = dispatchesRepository;

    public async Task<IEnumerable<Dispatch>> Handle(GetDispatchesQuery request, CancellationToken cancellationToken)
        => await _dispatchesRepository.GetDispatches(request);
}