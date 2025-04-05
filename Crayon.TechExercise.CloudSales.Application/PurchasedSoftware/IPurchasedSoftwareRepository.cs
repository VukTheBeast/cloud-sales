

namespace Crayon.TechExercise.CloudSales.Application.PurchasedSoftware;

public interface IPurchasedSoftwareRepository
{
    Task<Domain.PurchasedSoftware> GetById(int id);
    Task<IEnumerable<Domain.PurchasedSoftware>> GetPurchasedSoftwareByAccountAsync(int accountId);
    Task UpdateQuantityAsync(int id, int quantity);
    Task UpdateStatusAsync(int id, Domain.SoftwareState state);
    Task UpdateValidDateAsync(int id, DateTime newDate);
    Task AddSofware(int accountId, int softwareId, string name, int quantity);
}
