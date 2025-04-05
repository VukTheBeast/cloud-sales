
namespace Crayon.TechExercise.CloudSales.DB.Sql.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
