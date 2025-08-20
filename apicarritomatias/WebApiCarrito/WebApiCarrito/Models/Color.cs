using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Color
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
