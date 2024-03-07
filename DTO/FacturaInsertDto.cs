using FacturacionWeb.Models;
namespace FacturacionWeb.DTO;
public class FacturaInsertDto
{
    public DateTime Fecha { get; set; }
    public string? Cliente { get; set; }
    public int NIT { get; set; }
    public string stringDetalleFacutura { get; set; } = null!;
    public FacturaInsertDto()
    {
        Fecha = DateTime.Now;
    }
}