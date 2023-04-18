using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly DataContext _context;
    public ExpenseService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<AddExpenseDto>> AddExpense(AddExpenseDto addExpenseDto)
    {
        var existingParishes = _context.Parishes.FirstOrDefault(x=>x.ProductCode==addExpenseDto.ProductCode & x.Quantity>addExpenseDto.Quantity);
        existingParishes.Quantity = existingParishes.Quantity-addExpenseDto.Quantity;
        existingParishes.TotalAmount = existingParishes.Price*existingParishes.Quantity;

        var mapped = new Expense()
        {
             Id = existingParishes.Id,       
             Name = existingParishes.Name,
             ProductCode = addExpenseDto.ProductCode,     
             Quantity =  addExpenseDto.Quantity,    
             Price = existingParishes.Price,     
             TotalAmount = existingParishes.Price*addExpenseDto.Quantity,   
             Provider = existingParishes.Provider     
        };
        await _context.AddAsync(mapped);
        await _context.SaveChangesAsync();
        return new Response<AddExpenseDto>(addExpenseDto);
    }


    public async Task<Response<UpdateExpenseDto>> UpdateExpense(UpdateExpenseDto updateExpenseDto)
    {
        var existingExpense = _context.Expenses.FirstOrDefault(x=>x.ProductCode==updateExpenseDto.ProductCode);
        var existingParishes = _context.Parishes.FirstOrDefault(x=>x.ProductCode==updateExpenseDto.ProductCode);
        existingParishes.Quantity = existingParishes.Quantity-(updateExpenseDto.Quantity-existingExpense.Quantity);
        existingParishes.TotalAmount = existingParishes.Price*existingParishes.Quantity;

        existingExpense.Quantity = updateExpenseDto.Quantity;
        existingExpense.TotalAmount = existingExpense.Price*updateExpenseDto.Quantity;
        
         await _context.SaveChangesAsync();
         return new Response<UpdateExpenseDto>(updateExpenseDto);
    }

    public async Task<Response<List<GetExpenseDto>>> GetExpense()
    {
        var query = _context.Expenses.Select(x=> new GetExpenseDto()
        {
               ProductCode = x.ProductCode,
               Name = x.Name,
               Quantity = x.Quantity,
               Price = x.Price,
               TotalAmount = x.TotalAmount,
               Provider = x.Provider
        }).ToList();

        return new Response<List<GetExpenseDto>>(query);
    }

    public async Task<Response<string>> DeleteExpense(string productCode)
    {
        var existing =  _context.Expenses.FirstOrDefault(x=>x.ProductCode==productCode);
        if (existing == null) return new Response<string>("NotFound");
        _context.Expenses.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Expense Deleted");
    }

}
