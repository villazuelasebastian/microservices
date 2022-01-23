using AutoMapper;
using Microservice.NETCore.V6.Domain.Entities;
using Microservice.NETCore.V6.Infrastructure.Dispatches.DTO;

namespace Microservice.NETCore.V6.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DispatchModelResponse, Dispatch>();
        }
    }
}