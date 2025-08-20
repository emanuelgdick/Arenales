using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class TipoMovimientoCaja
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Signo { get; set; }

    public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; } = new List<CajaMovimiento>();
}
