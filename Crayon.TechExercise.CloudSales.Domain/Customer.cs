namespace Crayon.TechExercise.CloudSales.Domain;

public class Customer
{
    public int Id { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }
    public ICollection<Account> Accounts { get; set; }
}
