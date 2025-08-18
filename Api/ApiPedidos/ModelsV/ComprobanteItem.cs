using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class ComprobanteItem
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public int? IdComprobante { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ImpuestoUnitario { get; set; }
        public decimal TotalItem { get; set; }
        public decimal? Bonificacion { get; set; }
        public DateTime? FechaRemito { get; set; }
        public long? NumeroRemito { get; set; }
        public long? IdProductoMovimiento { get; set; }
        public string? Descripcion { get; set; }

        public virtual Comprobante? IdComprobanteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
