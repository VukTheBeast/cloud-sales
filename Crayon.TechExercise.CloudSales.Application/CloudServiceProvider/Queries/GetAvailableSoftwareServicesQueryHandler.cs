using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Queries;

public record GetAvailableSoftwareServicesQuery() : IRequest<IEnumerable<CcpSoftwareResult>>;

public class GetAvailableSoftwareServicesQueryHandler(ICcpClient ccpClient)
    : IRequestHandler<GetAvailableSoftwareServicesQuery, IEnumerable<CcpSoftwareResult>>
{
    public async Task<IEnumerable<CcpSoftwareResult>> Handle(GetAvailableSoftwareServicesQuery request, CancellationToken cancellationToken)
    {
        return await ccpClient.GetSoftwareListAsync();
    }
}
