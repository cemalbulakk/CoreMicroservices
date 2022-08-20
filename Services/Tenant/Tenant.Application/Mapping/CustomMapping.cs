using AutoMapper;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Queries.Response;

namespace Tenant.Application.Mapping;

public class CustomMapping : Profile
{
    public CustomMapping()
    {
        CreateMap<GetAllTenantQueryResponse, Domain.Entities.Tenant>().ReverseMap();
        CreateMap<CreateTenantCommandRequest, Domain.Entities.Tenant>().ReverseMap();
    }
}