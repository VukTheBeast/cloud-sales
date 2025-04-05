using AutoMapper;
using Crayon.TechExercise.CloudSales.Api.Responses;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;
using Crayon.TechExercise.CloudSales.Domain;


namespace Crayon.TechExercise.CloudSales.Api.MappingProfiles;

public class SoftwareMappingProfiles : Profile
{
    public SoftwareMappingProfiles()
    {
        CreateMap<PurchasedSoftware, PurchasedSoftwareResponse>();
        CreateMap<CcpSoftwareResult, SoftwareServiceResponse>();
    }
}
