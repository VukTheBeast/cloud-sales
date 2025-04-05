using Domai = Crayon.TechExercise.CloudSales.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Commands;
using FluentValidation;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands;

namespace Crayon.TechExercise.CloudSales.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IValidator<OrderSoftwareServiceCommand>, OrderSoftwareServiceCommandValidator>();
        services.AddScoped<IValidator<ChangePurchasedSoftwareQuantityCommand>, ChangePurchasedSoftwareQuantityCommandValidator>();

        return services;
    }
}
