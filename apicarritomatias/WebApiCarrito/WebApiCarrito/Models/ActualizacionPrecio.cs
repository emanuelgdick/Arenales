using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class ActualizacionPrecio
{
    public long Id { get; set; }

    public string? Modelo { get; set; }

    public long? IdMarca { get; set; }

    public decimal? PorcentajeImporte { get; set; }

    public decimal? Importe { get; set; }

    public DateTime Fecha { get; set; }

    public string? PrecioLista { get; set; }

    public string? Talledesde { get; set; }

    public string? Tallehasta { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
