using Microsoft.AspNetCore.Mvc;
using FacturacionWeb.Services;
using FacturacionWeb.DTO;

namespace FacturacionWeb.Controllers;

public class FacturaController : Controller
{
    private readonly ICommonService<ProductoDto, ProductoInsertDto> _productoService;
    private readonly ICommonService<FacturaDto, FacturaInsertDto> _facturaService;
    private readonly ILogger<FacturaController> _logger;
    public FacturaController(ILogger<FacturaController> logger, ICommonService<ProductoDto, ProductoInsertDto> productoService, ICommonService<FacturaDto, FacturaInsertDto> facturaService)
    {
        _logger = logger;
        _productoService = productoService;
        _facturaService = facturaService;
    }

    public async Task<ActionResult> CrearFacturaAsync()
    {
        var productos = await _productoService.Get();
        return View(productos);
    }
    [HttpPost]
    public async Task<ActionResult> CrearFactura(FacturaInsertDto facturaInsertDto)
    {
        await _facturaService.Create(facturaInsertDto);
        return RedirectToAction("Index", "Home");
    }
}
