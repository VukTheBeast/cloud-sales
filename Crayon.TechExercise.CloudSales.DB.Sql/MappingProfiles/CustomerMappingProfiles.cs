using AutoMapper;
using Crayon.TechExercise.CloudSales.Domain;
using Entity = Crayon.TechExercise.CloudSales.DB.Sql.Entities;

namespace Crayon.TechExercise.CloudSales.DB.Sql.MappingProfiles;

public class CustomerMappingProfiles : Profile
{
    public CustomerMappingProfiles()
    {
        CreateMap<Entity.Customer, Customer>()
            .ReverseMap();
    }
}
