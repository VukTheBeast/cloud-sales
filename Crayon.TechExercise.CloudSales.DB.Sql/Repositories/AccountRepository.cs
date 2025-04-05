using Crayon.TechExercise.CloudSales.Application.Account;
using Microsoft.EntityFrameworkCore;
using Crayon.TechExercise.CloudSales.DB.Sql.Entities;
using AutoMapper;

namespace Crayon.TechExercise.CloudSales.DB.Sql.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    private readonly CloudSalesContext _dbContext;
    private readonly DbSet<Account> _dbSet;
    private readonly IMapper _mapper;
    public AccountRepository(CloudSalesContext dBContext, IMapper mapper) : base(dBContext)
    {
        _dbContext = dBContext;
        _dbSet = dBContext.Set<Account>();
        _mapper = mapper;
    }

    public async Task<IEnumerable<Domain.Account>> GetAccountsByCustomerAsync(int customerId) 
    {
        var result = await _dbSet
            .Where(a => a.CustomerId == customerId)
            .Include(a => a.PurchasedSoftwares)
            .ToListAsync();

        return _mapper.Map<IEnumerable<Domain.Account>>(result);
    }

    public async Task<IEnumerable<Domain.Account>> GetAccountsAsync()
    {
        var result = await _dbSet
            .Include(a => a.PurchasedSoftwares)
            .ToListAsync();

        return _mapper.Map<IEnumerable<Domain.Account>>(result);
    }

    public async Task AddAccountAsync(Domain.Account accountDomain)
    {
        var entity = _mapper.Map<Account>(accountDomain);

        await AddAsync(entity);
    }

    public async Task<Domain.Account> GetAccount(int id)
    {
       var result = await GetByIdAsync(id);

       return _mapper.Map<Domain.Account>(result);
    }
}
