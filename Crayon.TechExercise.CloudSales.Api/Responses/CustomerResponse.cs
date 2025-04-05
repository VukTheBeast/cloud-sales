namespace Crayon.TechExercise.CloudSales.Api.Responses;

public record CustomerResponse
{
    public int Id { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }
    public ICollection<AccountResponse> Accounts { get; set; } = new List<AccountResponse>();
}
