namespace Crayon.TechExercise.CloudSales.DB.Sql.Entities;

public class Account : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<PurchasedSoftware> PurchasedSoftwares { get; set; }
}
