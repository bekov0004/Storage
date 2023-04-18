using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Interface;

public interface IExpenseService
{
   Task<Response<List<GetExpenseDto>>> GetExpense();
   Task<Response<AddExpenseDto>> AddExpense(AddExpenseDto addExpenseDto);    
   Task<Response<UpdateExpenseDto>> UpdateExpense(UpdateExpenseDto updateExpenseDto);
   Task<Response<string>> DeleteExpense(string productCode);


}
