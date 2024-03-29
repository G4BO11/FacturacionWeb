using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionWeb.Models;

public class DetalleFactura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public int ValorRegistro { get; set; }
    public int CodigoFactura { get; set; }
    public int CodigoProducto { get; set; }

    [ForeignKey("CodigoFactura")]
    public virtual Factura? Factura { get; set; }

    [ForeignKey("CodigoProducto")]
    public virtual Producto? Producto { get; set; }
}