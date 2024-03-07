using FacturacionWeb.Models;

namespace FacturacionWeb.Repository;
class DetalleFacturaRepository : IRepository<DetalleFactura>
{
    private readonly FacturacionWebContext _context;
    public DetalleFacturaRepository(FacturacionWebContext context)
    {
        _context = context;
    }
    public async Task Create(DetalleFactura entity) => await _context.DetalleFacturas.AddAsync(entity);

    public Task<IEnumerable<DetalleFactura>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task Save() => await _context.SaveChangesAsync();
}