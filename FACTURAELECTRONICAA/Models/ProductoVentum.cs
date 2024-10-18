using System;
using System.Collections.Generic;

namespace FACTURAELECTRONICAA.Models;

public partial class ProductoVentum
{
    public int ProductoVentaId { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? UnidadMedida { get; set; }

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
