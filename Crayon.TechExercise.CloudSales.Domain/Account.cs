namespace Crayon.TechExercise.CloudSales.Domain;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<PurchasedSoftware> PurchasedSoftwares { get; set; } = new List<PurchasedSoftware>();
}
