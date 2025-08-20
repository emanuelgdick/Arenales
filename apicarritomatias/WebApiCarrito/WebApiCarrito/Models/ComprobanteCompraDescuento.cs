using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ComprobanteCompraDescuento
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public long IdComprobanteCompra { get; set; }

    public virtual ComprobanteCompra IdComprobanteCompraNavigation { get; set; } = null!;
}
