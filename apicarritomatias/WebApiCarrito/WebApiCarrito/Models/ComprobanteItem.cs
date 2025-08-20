using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ComprobanteItem
{
    public long Id { get; set; }

    public long IdProducto { get; set; }

    public int? IdComprobante { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoUnitario { get; set; }

    public decimal TotalItem { get; set; }

    public decimal? Bonificacion { get; set; }

    public bool? Nc { get; set; }

    public long? IdComprobanteItemNc { get; set; }

    public virtual Comprobante? IdComprobanteNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
