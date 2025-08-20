using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class EstadoCredito
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
