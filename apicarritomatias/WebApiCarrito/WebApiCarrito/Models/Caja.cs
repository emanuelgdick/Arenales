using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Caja
{
    public int Id { get; set; }

    public long Numero { get; set; }

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public int IdVendedor { get; set; }

    public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; } = new List<CajaMovimiento>();

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
