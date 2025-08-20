using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class FormaPago
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
