using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class CarritoProducto
{
    public long Id { get; set; }

    public long? IdCarrito { get; set; }

    public long? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual Carrito? IdCarritoNavigation { get; set; } = null!;

    public virtual Producto? IdProductoNavigation { get; set; } = null!;
}
