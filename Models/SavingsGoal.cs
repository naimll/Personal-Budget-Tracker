namespace WebApplication1.Models
{
    public class SavingsGoal
    {
        public int Id { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
