using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class CondicionIva
{
    public long Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
