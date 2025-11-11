using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class CarritoProducto
{
    public long Id { get; set; }

    public long? IdCarrito { get; set; }
    
    [JsonIgnore]
    public virtual Carrito? IdCarritoNavigation { get; set; } = null!;

    [Column("IdProducto")]
    public long? IdProducto { get; set; }
    
    [ForeignKey("IdProducto")]
    public virtual Producto? IdProductoNavigation { get; set; } = null!;

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

 
}
