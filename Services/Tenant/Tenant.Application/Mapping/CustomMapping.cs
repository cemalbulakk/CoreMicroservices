using AutoMapper;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Commands.Response;
using Tenant.Application.CQRS.Queries.Response;

namespace Tenant.Application.Mapping;

public class CustomMapping : Profile
{
    public CustomMapping()
    {
        CreateMap<GetAllTenantQueryResponse, Domain.Entities.Tenant>().ReverseMap();
        CreateMap<CreateTenantCommandRequest, Domain.Entities.Tenant>().ReverseMap();
        CreateMap<CreateTenantCommandRequest, CreateTenantCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Tenant, CreateTenantCommandResponse>().ReverseMap();
        CreateMap<UpdateTenantCommandResponse, Domain.Entities.Tenant>().ReverseMap();
        CreateMap<UpdateTenantCommandRequest, Domain.Entities.Tenant>().ReverseMap();
    }
}