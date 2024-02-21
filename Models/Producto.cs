namespace FacturacionWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    [Required]
    public string? Referencia { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ValorUnitario { get; set; }
    public virtual ICollection<DetalleFactura>? DetalleFactura { get; set; }

}