using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class CarritoItem
    {
        public int Id { get; set; }
        public long IdCarrito { get; set; }
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Punitario { get; set; }
        public virtual Carrito? oCarrito { get; set; } = null!;
        public virtual Producto? oProducto { get; set; } = null!;
    }
}
