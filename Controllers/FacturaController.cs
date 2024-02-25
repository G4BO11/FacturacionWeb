using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FacturacionWeb.Models;
using FacturacionWeb.Services;
using FacturacionWeb.DTO;

namespace FacturacionWeb.Controllers;

public class FacturaController : Controller
{
    private readonly ILogger<FacturaController> _logger;
    public FacturaController(ILogger<FacturaController> logger)
    {
        _logger = logger;
    }

    public ActionResult CrearFactura()
    {
        return View();
    }
}
