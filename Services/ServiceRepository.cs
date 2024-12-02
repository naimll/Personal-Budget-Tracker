namespace WebApplication1.Services
{
    using System;
    using System.Collections.Generic;
    using WebApplication1.Context;
    using WebApplication1.Models;
    using WebApplication1.Models;

    public class ServiceRepository : IServiceRepository
    {
        private readonly BudgetTrackerDbContext _dbContext;

        public ServiceRepository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddTransaction(Transaction transaction)
        {
            try
            {
                _dbContext.Transactions.Add(transaction);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Transaction> GetTransactionsByUser(int userId)
        {
            return _dbContext.Transactions.Where(t => t.UserId == userId).ToList();
        }

        public bool SetMonthlyBudget(Budget budget)
        {
            try
            {
                _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Budget GetCurrentBudget(int userId)
        {
            return _dbContext.Budgets.FirstOrDefault(b => b.UserId == userId);
        }

        public bool SetSavingsGoal(SavingsGoal goal)
        {
            try
            {
                _dbContext.SavingsGoals.Add(goal);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SavingsGoal> GetSavingsGoalsByUser(int userId)
        {
            return _dbContext.SavingsGoals.Where(g => g.UserId == userId).ToList();
        }

        public Report GenerateMonthlyReport(int userId, string month)
        {
            var transactions = _dbContext.Transactions
                .Where(t => t.UserId == userId && t.Date.ToString("yyyy-MM") == month)
                .ToList();

            var totalIncome = transactions.Where(t => t.Category == "Income").Sum(t => t.Amount);
            var totalExpenses = transactions.Where(t => t.Category != "Income").Sum(t => t.Amount);

            return new Report
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                Period = month
            };
        }

        public bool DeleteTransaction(int transactionId)
        {
            try
            {
                var transaction = _dbContext.Transactions.Find(transactionId);
                if (transaction == null)
                    return false;

                _dbContext.Transactions.Remove(transaction);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string NotifyUser(int userId)
        {
            var goals = GetSavingsGoalsByUser(userId);
            foreach (var goal in goals)
            {
                if (goal.CurrentAmount >= goal.TargetAmount)
                {
                    return "Congratulations! You have reached your savings goal.";
                }
                else if (goal.TargetAmount - goal.CurrentAmount <= goal.TargetAmount * 0.1m)
                {
                    return "You are close to reaching your savings goal!";
                }
            }

            return "Keep saving toward your goal!";
        }
    }

}
