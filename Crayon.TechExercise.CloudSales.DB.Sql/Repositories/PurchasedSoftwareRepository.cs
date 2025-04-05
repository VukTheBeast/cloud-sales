using AutoMapper;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware;
using Crayon.TechExercise.CloudSales.DB.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Crayon.TechExercise.CloudSales.DB.Sql.Repositories;

public class PurchasedSoftwareRepository : Repository<PurchasedSoftware>, IPurchasedSoftwareRepository
{
    private readonly CloudSalesContext _dbContext;
    private readonly DbSet<PurchasedSoftware> _dbSet;
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;

    public PurchasedSoftwareRepository(CloudSalesContext dBContext, IMapper mapper, TimeProvider timeProvider) : base(dBContext)
    {
        _dbContext = dBContext;
        _dbSet = dBContext.Set<PurchasedSoftware>();
        _mapper = mapper;
        _timeProvider = timeProvider;
    }

    public async Task<IEnumerable<Domain.PurchasedSoftware>> GetPurchasedSoftwareByAccountAsync(int accountId)
    {
        var result = await _dbSet.Where(s => s.AccountId == accountId).ToListAsync();

        return _mapper.Map<IEnumerable<Domain.PurchasedSoftware>>(result);
    }

    public async Task UpdateQuantityAsync(int id, int quantity) 
    {
        var license = await _dbSet.FindAsync(id);

        if (license != null) 
        {
            license.Quantity = quantity;

            await UpdateAsync(license);
        }
    }

    public async Task UpdateStatusAsync(int id, Domain.SoftwareState state) 
    {
        var purchasedSoftware = await _dbSet.FindAsync(id);

        if (purchasedSoftware != null ) 
        {
            purchasedSoftware.State = (SoftwareState)state;

            await UpdateAsync(purchasedSoftware);
        }
    }

    public async Task UpdateValidDateAsync(int id, DateTime newDate)
    {
        var license = await _dbSet.FindAsync(id);

        if (license != null)
        {
            license.ValidTo = newDate;

            await UpdateAsync(license);
        }
    }

    public async Task AddSofware(int accountId, int softwareId, string name, int quantity)
    {
        var defaultValidTo = _timeProvider.GetUtcNow().AddMonths(6).UtcDateTime;

        await AddAsync(new PurchasedSoftware
        { 
            AccountId = accountId,
            Name = name,
            Quantity = quantity,
            State = SoftwareState.Active,
            ValidTo = defaultValidTo
        });
    }

    public async Task<Domain.PurchasedSoftware> GetById(int id)
    {
        var result = await GetByIdAsync(id);

        return _mapper.Map<Domain.PurchasedSoftware>(result);
    }
}
