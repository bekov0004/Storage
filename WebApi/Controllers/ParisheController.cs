using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class ParisheController:ControllerBase
{
    private readonly IParisheService _iParisheService; 

    public ParisheController(IParisheService iParisheService)
    {
        _iParisheService = iParisheService;
    }

    [HttpGet("GetParishe")]
    public async Task<Response<List<GetParisheDto>>> GetParishe()
    {
        return await _iParisheService.GetParishe();
    }

    [HttpPost("AddParishe")]
    public async Task<Response<AddParisheDto>> AddParishe([FromBody]AddParisheDto addParisheDto)
    {
       return await _iParisheService.AddParishe(addParisheDto);
    }

    [HttpPut("UpdateParishe")]
    public async Task<Response<UpdateParisheDto>> UpdateParishe([FromBody]UpdateParisheDto updateParisheDto)
    {
        return await _iParisheService.UpdateParishe(updateParisheDto);
    }

    [HttpDelete("DeleteParishe")]
    public async Task<Response<string>> DeleteParishe(string productCode)
    {
        return await _iParisheService.DeleteParishe(productCode);
    }
}
