using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class CarritoProducto
{
    public long Id { get; set; }

    public long? IdCarrito { get; set; }

    public long? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    [JsonIgnore]
    public virtual Carrito? IdCarritoNavigation { get; set; } = null!;

    
    public virtual Producto? IdProductoNavigation { get; set; } = null!;
}
