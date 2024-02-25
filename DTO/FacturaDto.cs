using FacturacionWeb.Models;

namespace FacturacionWeb.DTO;
public class FacturaDto
{
    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public string? Cliente { get; set; }
    public int NIT { get; set; }
    public int NumeroFactura { get; set; }
    public decimal ValorTotal { get; set; }
    public virtual ICollection<DetalleFactura>? DetalleFactura { get; set; }
}