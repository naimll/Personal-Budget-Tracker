namespace WebApplication1.Services
{
    using System.Collections.Generic;
    using WebApplication1.Models;

    public interface IServiceRepository
    {
        bool AddTransaction(Transaction transaction);
        List<Transaction> GetTransactionsByUser(int userId);
        bool SetMonthlyBudget(Budget budget);
        Budget GetCurrentBudget(int userId);
        bool SetSavingsGoal(SavingsGoal goal);
        List<SavingsGoal> GetSavingsGoalsByUser(int userId);
        Report GenerateMonthlyReport(int userId, string month);
        bool DeleteTransaction(int transactionId);
        string NotifyUser(int userId);
    }
}
