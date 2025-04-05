using AutoMapper;
using Crayon.TechExercise.CloudSales.Api.Responses;
using Crayon.TechExercise.CloudSales.Domain;


namespace Crayon.TechExercise.CloudSales.Api.MappingProfiles;

public class AccountMappingProfiles : Profile
{
    public AccountMappingProfiles()
    {
        CreateMap<Account, AccountResponse>();
    }
}
