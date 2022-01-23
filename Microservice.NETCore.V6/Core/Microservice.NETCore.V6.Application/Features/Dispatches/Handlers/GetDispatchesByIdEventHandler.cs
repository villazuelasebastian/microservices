using MediatR;
using Microservice.NETCore.V6.Application.Features.Dispatches.Queries;
using Microservice.NETCore.V6.Application.Interfaces.Repositories;
using Microservice.NETCore.V6.Domain.Entities;

namespace Microservice.NETCore.V6.Application.Features.Dispatches.Handlers
{
    public class GetDispatchesByIdEventHandler : IRequestHandler<GetDispatchesByIdQuery, Dispatch>
    {
        private readonly IDispatchesRepository _dispatchesRepository;

        public GetDispatchesByIdEventHandler(IDispatchesRepository dispatchesRepository)
            => _dispatchesRepository = dispatchesRepository;

        public Task<Dispatch> Handle(GetDispatchesByIdQuery request, CancellationToken cancellationToken)
            => _dispatchesRepository.GetDispatchesById(request);
    }
}