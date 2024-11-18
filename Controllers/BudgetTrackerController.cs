namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Models;
    using WebApplication1.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class BudgetTrackerController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public BudgetTrackerController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("transaction")]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            return null; 
        }

        [HttpGet("transaction/{userId}")]
        public IActionResult GetTransactionsByUser(int userId)
        {
            return null; 
        }

        [HttpDelete("transaction/{transactionId}")]
        public IActionResult DeleteTransaction(int transactionId)
        {
            return null;
        }

        [HttpPost("budget")]
        public IActionResult SetMonthlyBudget([FromBody] Budget budget)
        {
            return null; 
        }

        [HttpGet("budget/{userId}")]
        public IActionResult GetCurrentBudget(int userId)
        {
            return null;
        }

        [HttpPost("goal")]
        public IActionResult SetSavingsGoal([FromBody] SavingsGoal goal)
        {
            return null; 
        }

        [HttpGet("goal/{userId}")]
        public IActionResult GetSavingsGoalsByUser(int userId)
        {
            return null;
        }

        [HttpGet("report/{userId}/{month}")]
        public IActionResult GenerateMonthlyReport(int userId, string month)
        {
            return null; 
        }

        [HttpGet("notification/{userId}")]
        public IActionResult NotifyUser(int userId)
        {
            return null; 
        }
    }

}
