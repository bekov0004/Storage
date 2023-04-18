using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class ExpenseController:ControllerBase
{

    private readonly IExpenseService _iExpenseService;

    public ExpenseController(IExpenseService iExpenseService)
    {
        _iExpenseService = iExpenseService;
    } 

    [HttpGet("GetExpense")]
    public async Task<Response<List<GetExpenseDto>>> GetExpense()
    {
        return await _iExpenseService.GetExpense();
    }

    [HttpPost("AddExpense")]
    public async Task<Response<AddExpenseDto>> AddExpense([FromBody]AddExpenseDto addExpenseDto)
    {
        return await _iExpenseService.AddExpense(addExpenseDto);
    }

    [HttpPut("UpdateExpense")]
    public async Task<Response<UpdateExpenseDto>> UpdateExpense([FromBody]UpdateExpenseDto updateExpenseDto)
    {
        return await _iExpenseService.UpdateExpense(updateExpenseDto);
    }

    
    [HttpDelete("DeleteExpense")]
    public async Task<Response<string>> DeleteExpense(string productCode)
    {
        return await _iExpenseService.DeleteExpense(productCode);
    }
    



}
