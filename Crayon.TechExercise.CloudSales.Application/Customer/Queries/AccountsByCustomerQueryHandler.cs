using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.Customer.Queries;

public record AccountsByCustomerQuery(int customerId) : IRequest<IEnumerable<Domain.Account>>;
public class AccountsByCustomerQueryHandler(ICustomerRepository accountRepository) : IRequestHandler<AccountsByCustomerQuery, IEnumerable<Domain.Account>>
{
    public async Task<IEnumerable<Domain.Account>> Handle(AccountsByCustomerQuery request, CancellationToken cancellationToken) 
        => await accountRepository.GetAccountsByCustomerAsync(request.customerId);
}
