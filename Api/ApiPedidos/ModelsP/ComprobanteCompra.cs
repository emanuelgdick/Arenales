using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class ComprobanteCompra
    {
        public ComprobanteCompra()
        {
            ComprobanteCompraDescuentos = new HashSet<ComprobanteCompraDescuento>();
            ComprobanteCompraItems = new HashSet<ComprobanteCompraItem>();
        }

        public long Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Letra { get; set; } = null!;
        public decimal ImporteNeto { get; set; }
        public decimal Descuentos { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IvaTasa { get; set; }
        public decimal IvaTasax { get; set; }
        public decimal PercepcionIibb { get; set; }
        public decimal Total { get; set; }
        public long IdTipoComprobante { get; set; }
        public long IdMovimiento { get; set; }
        public long IdProveedor { get; set; }
        public int? IdCaja { get; set; }
        public decimal? Saldo { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? PuntoVenta { get; set; }

        public virtual Caja? IdCajaNavigation { get; set; }
        public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual TipoComprobante IdTipoComprobanteNavigation { get; set; } = null!;
        public virtual ICollection<ComprobanteCompraDescuento> ComprobanteCompraDescuentos { get; set; }
        public virtual ICollection<ComprobanteCompraItem> ComprobanteCompraItems { get; set; }
    }
}
