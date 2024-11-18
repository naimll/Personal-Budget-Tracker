﻿namespace WebApplication1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
