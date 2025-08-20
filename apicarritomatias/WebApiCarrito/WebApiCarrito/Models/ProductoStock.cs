using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ProductoStock
{
    public long Id { get; set; }

    public long IdProducto { get; set; }

    public long Cantidad { get; set; }

    public long IdSucursal { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
