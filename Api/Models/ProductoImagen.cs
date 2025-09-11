using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ProductoImagen
{
    public long Id { get; set; }

    public long IdProducto { get; set; }

    public string LinkImagen { get; set; } = null!;

    public bool Principal { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
