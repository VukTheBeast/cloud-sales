namespace Crayon.TechExercise.CloudSales.Api.Responses;

public record AccountResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public ICollection<PurchasedSoftwareResponse> PurchasedSoftwares { get; set; } = new List<PurchasedSoftwareResponse>();
}
