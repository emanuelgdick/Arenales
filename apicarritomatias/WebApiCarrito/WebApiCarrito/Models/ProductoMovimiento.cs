using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ProductoMovimiento
{
    public long Id { get; set; }

    public long IdProducto { get; set; }

    public long IdMovimiento { get; set; }

    public int Cantidad { get; set; }

    public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
