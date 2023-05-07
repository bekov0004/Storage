using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Domain.Entities;

namespace MVC.Controllers;

public class ParisheController : Controller
{
    private readonly IParisheService _iParisheService; 
    private readonly DataContext _context;

    public ParisheController(IParisheService iParisheService, DataContext context)
    {
        _iParisheService = iParisheService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetParishe()
    {
       var parishe = await _iParisheService.GetParishe();
        return View(parishe.Data);
    }

    [HttpGet]
    public IActionResult AddParishe()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddParishe(AddParisheDto addParisheDto)
    {
        await _iParisheService.AddParishe(addParisheDto);
        return RedirectToAction("GetParishe");
    }

    [HttpGet]
    public async Task<IActionResult> View(string id)
    {
        var parishe = _context.Parishes.FirstOrDefault(x=>x.Id==id);
        if(parishe != null)
        {
            var mapped = new UpdateParisheDto()
               {
                Id =parishe.Id ,
                Name = parishe.Name ,
                ProductCode =parishe.ProductCode ,
                Quantity =parishe.Quantity ,
                Price =parishe.Price ,
                Provider =parishe.Provider 
              };
              return await  Task.Run(() => View("View",mapped));
        }

        return RedirectToAction("GetParishe");

    }

    [HttpPost]
    public async Task<IActionResult> View(UpdateParisheDto updateParisheDto)
    {
        await _iParisheService.UpdateParishe(updateParisheDto);
         return RedirectToAction("GetParishe");
    }


    public async Task<IActionResult> Delete(UpdateParisheDto updateParisheDto)
    {
        await _iParisheService.DeleteParishe(updateParisheDto.Id);
         return RedirectToAction("GetParishe");
    }

}
