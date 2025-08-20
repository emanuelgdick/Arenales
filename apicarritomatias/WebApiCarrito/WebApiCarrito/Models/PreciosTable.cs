using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class PreciosTable
{
    public string? CodigoBarras { get; set; }

    public string? Costo { get; set; }

    public string? Precio { get; set; }

    public string? PrecioSinIva { get; set; }
}
