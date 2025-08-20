using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ComprobanteCompra
{
    public long Id { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public string Letra { get; set; } = null!;

    public decimal ImporteNeto { get; set; }

    public decimal Descuentos { get; set; }

    public decimal Subtotal { get; set; }

    public decimal IvaTasa1 { get; set; }

    public decimal IvaTasa2 { get; set; }

    public decimal PercepcionIibb { get; set; }

    public decimal Total { get; set; }

    public long IdTipoComprobante { get; set; }

    public long IdMovimiento { get; set; }

    public long IdProveedor { get; set; }

    public long? IdCaja { get; set; }

    public string? PuntoVenta { get; set; }

    public decimal? Saldo { get; set; }

    public decimal? OtrosImpuestos { get; set; }

    public virtual ICollection<ComprobanteCompraDescuento> ComprobanteCompraDescuentos { get; set; } = new List<ComprobanteCompraDescuento>();

    public virtual ICollection<ComprobanteCompraItem> ComprobanteCompraItems { get; set; } = new List<ComprobanteCompraItem>();

    public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual TipoComprobante IdTipoComprobanteNavigation { get; set; } = null!;
}
