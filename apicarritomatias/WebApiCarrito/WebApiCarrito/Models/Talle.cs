using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Talle
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Numero { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
