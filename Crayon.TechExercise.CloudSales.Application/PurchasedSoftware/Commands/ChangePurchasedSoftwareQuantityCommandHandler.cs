using FluentValidation;
using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands
{
    public record ChangePurchasedSoftwareQuantityCommand(int id, int newQuantity): IRequest;
    public class ChangePurchasedSoftwareQuantityCommandHandler(IValidator<ChangePurchasedSoftwareQuantityCommand> validator, IPurchasedSoftwareRepository purchasedSoftwareRepository) : IRequestHandler<ChangePurchasedSoftwareQuantityCommand>
    {
        public async Task Handle(ChangePurchasedSoftwareQuantityCommand request, CancellationToken cancellationToken)
        {
            if(validator.Validate(request).IsValid) 
            {
                return;
            }

            await purchasedSoftwareRepository.UpdateQuantityAsync(request.id, request.newQuantity);
        }
    }
}
