using System;
using System.Collections.Generic;

namespace FACTURAELECTRONICAA.Models;

public partial class FacturaCabecera
{
    public int FacturaId { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? DireccionCliente { get; set; }

    public string TipoMoneda { get; set; } = null!;

    public string? FormaPago { get; set; }

    public string? Observacion { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
