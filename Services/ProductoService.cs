using FacturacionWeb.DTO;
using FacturacionWeb.Models;
using FacturacionWeb.Repository;

namespace FacturacionWeb.Services;

public class ProductoService : ICommonService<ProductoDto, ProductoInsertDto>
{
    private readonly IRepository<Producto> _productoRepository;

    public ProductoService(IRepository<Producto> productoRepository)
    {
        _productoRepository = productoRepository;
    }
    public Task Create(ProductoInsertDto insertDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductoDto>> Get()
    {
        var productos = await _productoRepository.Get();

        return productos.Select(p => new ProductoDto()
        {
            Codigo = p.Codigo,
            Referencia = p.Referencia,
            Descripcion = p.Descripcion,
            ValorUnitario = p.ValorUnitario
        });
    }
}