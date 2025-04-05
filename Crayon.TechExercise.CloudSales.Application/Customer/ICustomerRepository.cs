namespace Crayon.TechExercise.CloudSales.Application.Customer
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Domain.Account>> GetAccountsByCustomerAsync(int customerId);
    }
}
