using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Deposito
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;
}
