using Microservice.NETCore.V6.Application.Features.Dispatches.Queries;
using Microservice.NETCore.V6.Domain.Entities;

namespace Microservice.NETCore.V6.Application.Interfaces.Repositories;

public interface IDispatchesRepository
{
    Task<IEnumerable<Dispatch>> GetDispatches(GetDispatchesQuery getDispatchesQuery);

    Task<Dispatch> GetDispatchesById(GetDispatchesByIdQuery getDispatchesById);
}