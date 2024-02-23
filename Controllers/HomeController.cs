using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FacturacionWeb.Models;
using FacturacionWeb.Services;
using FacturacionWeb.DTO;

namespace FacturacionWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICommonService<ProductoDto, ProductoInsertDto> _productoService;


    public HomeController(ILogger<HomeController> logger, ICommonService<ProductoDto, ProductoInsertDto> productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var productos = await _productoService.Get();
        return View(productos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
