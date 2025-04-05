using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands;

public class ChangePurchasedSoftwareQuantityCommandValidator : AbstractValidator<ChangePurchasedSoftwareQuantityCommand>
{
    public ChangePurchasedSoftwareQuantityCommandValidator()
    {
        RuleFor(c => c.id).NotEmpty();
        RuleFor(x => x.newQuantity)
            .GreaterThan(0)
            .NotEmpty();
    }
}
