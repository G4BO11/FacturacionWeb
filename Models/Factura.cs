using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionWeb.Models;

public class Factura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public string? Cliente { get; set; }
    [Required]
    public int NIT { get; set; }
    public int NumeroFactura { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ValorTotal { get; set; }
    public virtual ICollection<DetalleFactura>? DetalleFactura { get; set; }

}