using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class ProductoMovimiento
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public long IdMovimiento { get; set; }
        public decimal Cantidad { get; set; }
        public bool? Facturado { get; set; }
        public decimal? Precio { get; set; }
        public string? Descripcion { get; set; }

        public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
