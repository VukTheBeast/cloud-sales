using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands;

public record CancelPurchasedSoftwareCommand(int id) : IRequest;
public class CancelPurchasedSoftwareCommandHandler(IPurchasedSoftwareRepository purchasedSoftwareRepository) : IRequestHandler<CancelPurchasedSoftwareCommand>
{
    public async Task Handle(CancelPurchasedSoftwareCommand request, CancellationToken cancellationToken)
    {
        await purchasedSoftwareRepository.UpdateStatusAsync(request.id, Domain.SoftwareState.Canceled);
    }
}
