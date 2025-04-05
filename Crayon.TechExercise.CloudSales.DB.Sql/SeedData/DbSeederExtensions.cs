using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crayon.TechExercise.CloudSales.DB.Sql.SeedData;

public static class DbSeederExtensions
{
    public static IServiceCollection AddSeedData(this IServiceCollection services)
    {
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<CloudSalesContext>();
            context.Seed();
        }

        return services;
    }
}
