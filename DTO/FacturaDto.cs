namespace FacturacionWeb.DTO;
public class FacturaDto
{
    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal ValorUnitario { get; set; }
}