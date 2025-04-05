using AutoMapper;
using Crayon.TechExercise.CloudSales.Application.Customer;
using Crayon.TechExercise.CloudSales.DB.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.TechExercise.CloudSales.DB.Sql.Repositories
{
    internal class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly CloudSalesContext _dbContext;
        private readonly DbSet<Customer> _dbSet;
        private readonly IMapper _mapper;
        public CustomerRepository(CloudSalesContext dBContext, IMapper mapper) : base(dBContext)
        {
            _dbContext = dBContext;
            _dbSet = dBContext.Set<Customer>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Domain.Account>> GetAccountsByCustomerAsync(int customerId)
        {
            var result = await _dbSet
                .Where(a => a.Id == customerId)
                .SelectMany(s => s.Accounts)
                .Include(s => s.PurchasedSoftwares)
                .ToListAsync();

            return _mapper.Map<IEnumerable<Domain.Account>>(result);
        }
    }
}
