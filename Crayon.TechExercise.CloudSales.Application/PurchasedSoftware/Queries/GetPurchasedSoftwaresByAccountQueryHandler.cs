using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Queries;

public record GetPurchasedSoftwaresByAccountQuery(int accountId) : IRequest<IEnumerable<Domain.PurchasedSoftware>>;
public class GetPurchasedSoftwaresByAccountQueryHandler(IPurchasedSoftwareRepository purchasedSoftwareRepository) 
    : IRequestHandler<GetPurchasedSoftwaresByAccountQuery, IEnumerable<Domain.PurchasedSoftware>>
{
    public async Task<IEnumerable<Domain.PurchasedSoftware>> Handle(GetPurchasedSoftwaresByAccountQuery request, CancellationToken cancellationToken)
    {
        var results = await purchasedSoftwareRepository.GetPurchasedSoftwareByAccountAsync(request.accountId);

        return results;
    }
}
