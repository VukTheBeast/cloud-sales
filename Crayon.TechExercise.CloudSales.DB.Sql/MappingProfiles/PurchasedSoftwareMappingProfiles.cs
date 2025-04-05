using AutoMapper;
using Crayon.TechExercise.CloudSales.Domain;
using Entity = Crayon.TechExercise.CloudSales.DB.Sql.Entities;


namespace Crayon.TechExercise.CloudSales.DB.Sql.MappingProfiles;

public class PurchasedSoftwareMappingProfiles : Profile
{
    public PurchasedSoftwareMappingProfiles()
    {
        CreateMap<Entity.PurchasedSoftware, PurchasedSoftware>()
            .ReverseMap();
    }
}
