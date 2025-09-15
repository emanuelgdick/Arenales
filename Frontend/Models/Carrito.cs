using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class Carrito
{
    public long Id { get; set; }

    public DateTime? Fecha { get; set; }

    public long? IdEstadoCarrito { get; set; }

    public int? IdComprobante { get; set; }

    public long? IdUsuario { get; set; }

    public decimal? Total { get; set; }

    public int? Numero { get; set; }


    public virtual ICollection<CarritoProducto>? CarritoProductos { get; set; } = new List<CarritoProducto>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Comprobante? IdComprobanteNavigation { get; set; }

    public virtual EstadoCarrito? IdEstadoCarritoNavigation { get; set; }
}
