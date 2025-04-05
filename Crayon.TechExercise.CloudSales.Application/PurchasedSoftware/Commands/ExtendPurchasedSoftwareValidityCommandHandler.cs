using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands
{
    public record ExtendPurchasedSoftwareValidityCommand(int id, DateTime newDate) : IRequest;
    public class ExtendPurchasedSoftwareValidityCommandHandler(IPurchasedSoftwareRepository purchasedSoftwareRepository) : IRequestHandler<ExtendPurchasedSoftwareValidityCommand>
    {
        public async Task Handle(ExtendPurchasedSoftwareValidityCommand request, CancellationToken cancellationToken)
        {
            var purchasedSoftware = await purchasedSoftwareRepository.GetById(request.id);

            if (purchasedSoftware == null) 
            {
                throw new NullReferenceException(nameof(purchasedSoftware));
            }

            if (!purchasedSoftware.CanExtendLicense(request.newDate)) 
            {
                throw new InvalidOperationException("Can not extend license, license new date should be greater then software current valid date");
            }

            await purchasedSoftwareRepository.UpdateValidDateAsync(request.id, request.newDate);
        }
    }
}
