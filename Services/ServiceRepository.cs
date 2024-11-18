namespace WebApplication1.Services
{
    using System;
    using System.Collections.Generic;
    using WebApplication1.Models;
    using WebApplication1.Models;

    public class ServiceRepository
    {
        public bool AddTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool SetMonthlyBudget(Budget budget)
        {
            throw new NotImplementedException();
        }

        public Budget GetCurrentBudget(int userId)
        {
            throw new NotImplementedException();
        }

        public bool SetSavingsGoal(SavingsGoal goal)
        {
            throw new NotImplementedException();
        }

        public List<SavingsGoal> GetSavingsGoalsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Report GenerateMonthlyReport(int userId, string month)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public string NotifyUser(int userId)
        {
            throw new NotImplementedException();
        }
    }

}
