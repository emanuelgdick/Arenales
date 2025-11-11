using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Rubro
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
