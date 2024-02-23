namespace FacturacionWeb.DTO;
public class ProductoDto
{
    public int Codigo { get; set; }
    public string? Referencia { get; set; }
    public string? Descripcion { get; set; }
    public decimal ValorUnitario { get; set; }
}