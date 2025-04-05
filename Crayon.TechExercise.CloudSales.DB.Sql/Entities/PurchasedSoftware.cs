
namespace Crayon.TechExercise.CloudSales.DB.Sql.Entities;

public class PurchasedSoftware : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public SoftwareState State { get; set; }
    public DateTime ValidTo { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; internal set; }
}

public enum SoftwareState 
{
    Uknown = 0,
    Active = 1,
    Suspended = 2,
    Canceled = 3,
}
