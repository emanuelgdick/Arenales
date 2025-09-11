using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class ProductoStock
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public long IdSucursal { get; set; }
        public bool? Facturado { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
