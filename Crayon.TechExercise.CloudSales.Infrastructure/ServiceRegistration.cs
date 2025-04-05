using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;
using Crayon.TechExercise.CloudSales.Infrastructure.Clients;
using Crayon.TechExercise.CloudSales.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace Crayon.TechExercise.CloudSales.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<CcpClientApiConfiguration>(options =>
        {
            configuration.GetSection("ExternalServices:CcpService").Bind(options);
        });

        service.AddHttpClient<ICcpClient, CcpApiClient>((sp, client) =>
        {
            var config = sp.GetRequiredService<IOptions<CcpClientApiConfiguration>>().Value;

            client.BaseAddress = new Uri(config.Uri);
        });

        return service;
    }
}
