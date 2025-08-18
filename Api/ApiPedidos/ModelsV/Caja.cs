using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Caja
    {
        public Caja()
        {
            CajaMovimientos = new HashSet<CajaMovimiento>();
            ComprobanteCompras = new HashSet<ComprobanteCompra>();
            Comprobantes = new HashSet<Comprobante>();
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public long Numero { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int IdVendedor { get; set; }

        public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; }
        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
