using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ProveedorCuentaCorriente
{
    public int Id { get; set; }

    public int IdProveedor { get; set; }

    public int EstadoCuentaCorriente { get; set; }

    public decimal Saldo { get; set; }
}
