using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Services;

[ApiController]
[Route("api/[controller]")]
public class BudgetTrackerController : ControllerBase
{
    private readonly IServiceRepository _serviceRepository;

    public BudgetTrackerController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }


    [HttpPost("transaction")]
    public IActionResult AddTransaction([FromBody] Transaction transaction)
    {
        if (transaction == null)
            return BadRequest("Transaction data is invalid.");

        var isSuccess = _serviceRepository.AddTransaction(transaction);
        if (isSuccess)
            return Ok("Transaction added successfully.");
        return BadRequest("Failed to add transaction.");
    }

    [HttpGet("transaction/{userId}")]
    public IActionResult GetTransactionsByUser(int userId)
    {
        var transactions = _serviceRepository.GetTransactionsByUser(userId);
        if (transactions == null || !transactions.Any())
            return NotFound("No transactions found for the user.");
        return Ok(transactions);
    }

    [HttpDelete("transaction/{transactionId}")]
    public IActionResult DeleteTransaction(int transactionId)
    {
        var isSuccess = _serviceRepository.DeleteTransaction(transactionId);
        if (isSuccess)
            return Ok("Transaction deleted successfully.");
        return NotFound("Transaction not found.");
    }

    [HttpPost("budget")]
    public IActionResult SetMonthlyBudget([FromBody] Budget budget)
    {
        if (budget == null)
            return BadRequest("Budget data is invalid.");

        var isSuccess = _serviceRepository.SetMonthlyBudget(budget);
        if (isSuccess)
            return Ok("Budget set successfully.");
        return BadRequest("Failed to set budget.");
    }

    [HttpGet("budget/{userId}")]
    public IActionResult GetCurrentBudget(int userId)
    {
        var budget = _serviceRepository.GetCurrentBudget(userId);
        if (budget == null)
            return NotFound("No budget found for the user.");
        return Ok(budget);
    }

    [HttpPost("goal")]
    public IActionResult SetSavingsGoal([FromBody] SavingsGoal goal)
    {
        if (goal == null)
            return BadRequest("Savings goal data is invalid.");

        var isSuccess = _serviceRepository.SetSavingsGoal(goal);
        if (isSuccess)
            return Ok("Savings goal set successfully.");
        return BadRequest("Failed to set savings goal.");
    }

    [HttpGet("goal/{userId}")]
    public IActionResult GetSavingsGoalsByUser(int userId)
    {
        var goals = _serviceRepository.GetSavingsGoalsByUser(userId);
        if (goals == null || !goals.Any())
            return NotFound("No savings goals found for the user.");
        return Ok(goals);
    }

    [HttpGet("report/{userId}/{month}")]
    public IActionResult GenerateMonthlyReport(int userId, string month)
    {
        var report = _serviceRepository.GenerateMonthlyReport(userId, month);
        if (report == null)
            return NotFound("No report available for the given period.");
        return Ok(report);
    }

    [HttpGet("notification/{userId}")]
    public IActionResult NotifyUser(int userId)
    {
        var message = _serviceRepository.NotifyUser(userId);
        if (string.IsNullOrEmpty(message))
            return NotFound("No notifications available.");
        return Ok(message);
    }
}
