using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Estado
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
}
