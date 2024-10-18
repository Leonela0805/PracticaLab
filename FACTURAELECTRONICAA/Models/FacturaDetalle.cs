using System;
using System.Collections.Generic;

namespace FACTURAELECTRONICAA.Models;

public partial class FacturaDetalle
{
    public int DetalleId { get; set; }

    public int FacturaId { get; set; }

    public int ProductoVentaId { get; set; }

    public decimal SubTotalVentas { get; set; }

    public int CantidaProducto { get; set; }

    public decimal Anticipos { get; set; }

    public decimal Descuentos { get; set; }

    public decimal ValorVenta { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public virtual FacturaCabecera Factura { get; set; } = null!;

    public virtual ProductoVentum ProductoVenta { get; set; } = null!;
}
