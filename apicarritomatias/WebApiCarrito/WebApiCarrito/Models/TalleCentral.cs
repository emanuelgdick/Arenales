using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class TalleCentral
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Numero { get; set; }
}
