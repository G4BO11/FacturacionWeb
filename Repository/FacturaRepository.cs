using FacturacionWeb.Models;

namespace FacturacionWeb.Repository;
class FacturaRepository : IRepository<Factura>
{
    private readonly FacturacionWebContext _context;
    public FacturaRepository(FacturacionWebContext context)
    {
        _context = context;
    }
    public async Task Create(Factura entity) => await _context.Facturas.AddAsync(entity);

    public Task<IEnumerable<Factura>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task Save() => await _context.SaveChangesAsync();
}