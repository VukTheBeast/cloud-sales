using FluentValidation;

namespace Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Commands;

public class OrderSoftwareServiceCommandValidator : AbstractValidator<OrderSoftwareServiceCommand>
{
    public OrderSoftwareServiceCommandValidator()
    {
        RuleFor(x => x.accountId).NotEmpty();
        RuleFor(x => x.softwareServiceId).NotEmpty();
        RuleFor(x => x.quantity)
            .NotEmpty()
            .GreaterThan(0);
    }
}
