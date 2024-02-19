namespace FacturacionWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Auditoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    public int CodigoFactura { get; set; }
    [ForeignKey("CodigoFactura")]
    public Factura? Factura { get; set; }
}