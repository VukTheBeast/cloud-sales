using FluentValidation;
using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands
{
    public record ChangePurchasedSoftwareQuantityCommand(int id, int newQuantity): IRequest;
    public class ChangePurchasedSoftwareQuantityCommandHandler(IValidator<ChangePurchasedSoftwareQuantityCommand> validator, IPurchasedSoftwareRepository purchasedSoftwareRepository) : IRequestHandler<ChangePurchasedSoftwareQuantityCommand>
    {
        public async Task Handle(ChangePurchasedSoftwareQuantityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await purchasedSoftwareRepository.UpdateQuantityAsync(request.id, request.newQuantity);
        }
    }
}
