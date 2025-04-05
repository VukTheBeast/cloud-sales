using Crayon.TechExercise.CloudSales.Application.Account;
using Crayon.TechExercise.CloudSales.Application.Customer;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware;
using Crayon.TechExercise.CloudSales.Application.Repositories;
using Crayon.TechExercise.CloudSales.DB.Sql.MappingProfiles;
using Crayon.TechExercise.CloudSales.DB.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crayon.TechExercise.CloudSales.DB.Sql;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration Configuration) 
        => services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<IPurchasedSoftwareRepository, PurchasedSoftwareRepository>()
            .AddDbContext<CloudSalesContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
            .AddAutoMapper(opts => opts.AddMaps(typeof(AccountMappingProfiles), typeof(CustomerMappingProfiles), typeof(PurchasedSoftwareMappingProfiles)));
}
