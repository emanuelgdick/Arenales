using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Sucursal
{
    public long Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool? EsCorriente { get; set; }

    public string? PathRemitos { get; set; }

    public string? PathPrecios { get; set; }

    public string? Coneccion { get; set; }

    public string? Mail { get; set; }

    public string? MailPassword { get; set; }

    public string? PathDownloads { get; set; }

    public virtual ICollection<ProductoStock> ProductoStocks { get; set; } = new List<ProductoStock>();

    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
}
