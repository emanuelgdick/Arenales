using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Marca
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<ActualizacionPrecio> ActualizacionPrecios { get; set; } = new List<ActualizacionPrecio>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
