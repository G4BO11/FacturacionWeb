using Microsoft.EntityFrameworkCore;

namespace FacturacionWeb.Models;

public class FacturacionWebContext : DbContext
{
    public FacturacionWebContext(DbContextOptions<FacturacionWebContext> options) : base(options) { }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetalleFacturas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Auditoria> Auditorias { get; set; }

}