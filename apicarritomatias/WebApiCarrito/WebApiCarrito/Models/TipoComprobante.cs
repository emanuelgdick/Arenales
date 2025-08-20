using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class TipoComprobante
{
    public long Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Signo { get; set; }

    public string? Letra { get; set; }

    public bool? EsFiscal { get; set; }

    public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; } = new List<ComprobanteCompra>();

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
