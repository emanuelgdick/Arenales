using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class ComprobanteCompraItem
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public long IdComprobanteCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ImpuestoUnitario { get; set; }
        public decimal TotalItem { get; set; }

        public virtual ComprobanteCompra IdComprobanteCompraNavigation { get; set; } = null!;
    }
}
