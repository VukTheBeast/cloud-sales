using Crayon.TechExercise.CloudSales.Api.MappingProfiles;

namespace Crayon.TechExercise.CloudSales.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddAutoMapper(opts => opts.AddMaps(typeof(AccountMappingProfiles), typeof(CustomerMappingProfiles), typeof(SoftwareMappingProfiles)));
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
