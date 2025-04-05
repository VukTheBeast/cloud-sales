using AutoMapper;
using Crayon.TechExercise.CloudSales.Domain;
using Entity = Crayon.TechExercise.CloudSales.DB.Sql.Entities;

namespace Crayon.TechExercise.CloudSales.DB.Sql.MappingProfiles;

public class AccountMappingProfiles : Profile
{
    public AccountMappingProfiles()
    {
        CreateMap<Entity.Account, Account>()
            .ReverseMap();
    }
}
