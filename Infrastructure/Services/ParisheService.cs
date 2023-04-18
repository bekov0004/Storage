namespace Infrastructure.Services;

using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Interface;
using Infrastructure.Data;
using Domain.Entities;

public class ParisheService : IParisheService
{
    private readonly DataContext _context;
    public ParisheService(DataContext context)
    {
        _context = context;
    }


    public async Task<Response<AddParisheDto>> AddParishe(AddParisheDto addParisheDto)
    {
        var mapped = new Parishe()
        {
         Id = Guid.NewGuid().ToString(),
         Name = addParisheDto.Name,
         ProductCode = addParisheDto.ProductCode,
         Quantity = addParisheDto.Quantity,
         Price = addParisheDto.Price,
         TotalAmount = addParisheDto.Price*addParisheDto.Quantity,
         Provider = addParisheDto.Provider
        };

        await _context.AddAsync(mapped);
        await _context.SaveChangesAsync();
        
        return new Response<AddParisheDto>(addParisheDto);
    }

    public async Task<Response<UpdateParisheDto>> UpdateParishe(UpdateParisheDto updateParisheDto)
    {
        var mapped = new Parishe()
        {
         Id =updateParisheDto.Id ,
         Name = updateParisheDto.Name ,
         ProductCode =updateParisheDto.ProductCode ,
         Quantity =updateParisheDto.Quantity ,
         Price =updateParisheDto.Price ,
         TotalAmount = updateParisheDto.Price*updateParisheDto.Quantity,
         Provider =updateParisheDto.Provider 
        };

         _context.Parishes.Update(mapped);
         await _context.SaveChangesAsync();
         return new Response<UpdateParisheDto>(updateParisheDto);
    }

    public async Task<Response<List<GetParisheDto>>> GetParishe()
    {
        var query = _context.Parishes.Select(x=> new GetParisheDto()
        {
               ProductCode = x.ProductCode,
               Name = x.Name,
               Quantity = x.Quantity,
               Price = x.Price,
               TotalAmount = x.TotalAmount,
               Provider = x.Provider
        }).ToList();

        return new Response<List<GetParisheDto>>(query);
    }


    public async Task<Response<string>> DeleteParishe(string productCode)
    {
        var existing =  _context.Parishes.FirstOrDefault(x=>x.ProductCode==productCode);
        if (existing == null) return new Response<string>("NotFound");
        _context.Parishes.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Parishes Deleted");
    }

}
