namespace Crayon.TechExercise.CloudSales.Application.Account;

public interface IAccountRepository
{
    Task AddAccountAsync(Domain.Account account);

    Task<Domain.Account> GetAccount(int id);
    Task<IEnumerable<Domain.Account>> GetAccountsAsync();
    Task<IEnumerable<Domain.Account>> GetAccountsByCustomerAsync(int customerId);

}
