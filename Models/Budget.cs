namespace WebApplication1.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}
