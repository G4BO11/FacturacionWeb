using FacturacionWeb.DTO;
using FacturacionWeb.Models;
using FacturacionWeb.Repository;
using Newtonsoft.Json;

namespace FacturacionWeb.Services;

class FacturaService : ICommonService<FacturaDto, FacturaInsertDto>
{
    private readonly IRepository<Factura> _facturaRepository;
    private readonly IRepository<DetalleFactura> _detalleRepository;

    public FacturaService(IRepository<Factura> facturaRepository, IRepository<DetalleFactura> detalleRepository)
    {
        _facturaRepository = facturaRepository;
        _detalleRepository = detalleRepository;
    }

    public async Task Create(FacturaInsertDto insertDto)
    {
        //Convirtiendo en JSON
        List<DetalleFactura>? detalles = JsonConvert.DeserializeObject<List<DetalleFactura>>(insertDto.stringDetalleFacutura);
        decimal valorCompletoFactura = detalles.Sum(detalle => detalle.ValorRegistro);

        Factura factura = new()
        {
            Cliente = insertDto.Cliente,
            Fecha = insertDto.Fecha,
            NIT = insertDto.NIT,
            ValorTotal = valorCompletoFactura
        };

        await _facturaRepository.Create(factura);
        await _facturaRepository.Save();

        var facturaID = factura.Codigo;


        foreach (var detalle in detalles)
        {
            DetalleFactura detallito = new()
            {
                CodigoProducto = detalle.CodigoProducto,
                CodigoFactura = facturaID,
                Cantidad = detalle.Cantidad,
                ValorRegistro = detalle.ValorRegistro,
            };
            await _detalleRepository.Create(detallito);
        }
        
        await _detalleRepository.Save();

    }

    public Task<IEnumerable<FacturaDto>> Get()
    {
        throw new NotImplementedException();
    }
}