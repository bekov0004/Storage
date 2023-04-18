namespace Infrastructure.Interface;
using Domain.Wrapper;
using Domain.Dtos;
public interface IParisheService
{
   Task<Response<List<GetParisheDto>>> GetParishe();
   Task<Response<AddParisheDto>> AddParishe(AddParisheDto addParisheDto);
   Task<Response<UpdateParisheDto>> UpdateParishe(UpdateParisheDto updateParisheDto);
   Task<Response<string>> DeleteParishe(string productCode);

}
