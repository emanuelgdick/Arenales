using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Movimiento
{
    public long Id { get; set; }

    public long IdTipoMovimiento { get; set; }

    public long? IdSucursalIngreso { get; set; }

    public long? IdSucursalEgreso { get; set; }

    public DateTime Fecha { get; set; }

    public long Numero { get; set; }

    public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; } = new List<ComprobanteCompra>();

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();

    public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; } = null!;

    public virtual ICollection<ProductoMovimiento> ProductoMovimientos { get; set; } = new List<ProductoMovimiento>();
}
