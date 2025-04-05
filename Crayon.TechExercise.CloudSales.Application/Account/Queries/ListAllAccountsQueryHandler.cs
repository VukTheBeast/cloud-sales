using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.Account.Queries;

public record ListAllAccountsQuery() : IRequest<IEnumerable<Domain.Account>>;
public class ListAllAccountsQueryHandler(IAccountRepository accountRepository) : IRequestHandler<ListAllAccountsQuery, IEnumerable<Domain.Account>>
{
    public async Task<IEnumerable<Domain.Account>> Handle(ListAllAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await accountRepository.GetAccountsAsync();
        return result;
    }
}
