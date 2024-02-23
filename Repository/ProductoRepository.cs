using FacturacionWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturacionWeb.Repository;
public class ProductoRepository : IRepository<Producto>
{
    private readonly FacturacionWebContext _context;
    public ProductoRepository(FacturacionWebContext context)
    {
        _context = context;
    }
    public Task Create(Producto entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Producto>> Get() => await _context.Productos.ToListAsync();

    public async Task Save() => await _context.SaveChangesAsync();
}