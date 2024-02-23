using FacturacionWeb.Models;
namespace FacturacionWeb.DTO;
public class FacturaInsertDto
{
    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public string? Cliente { get; set; }
    public int NIT { get; set; }
    public decimal NumeroFactura { get; set; }
    public AplicaDescuento AplicaDescuento { get; set; }
    public decimal ValorDescuento { get; set; }
    public decimal ValorTotal { get; set; }
    public ICollection<DetalleFactura>? ListDetalleFactura { get; set; }
}