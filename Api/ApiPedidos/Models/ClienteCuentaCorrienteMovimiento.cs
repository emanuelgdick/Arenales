using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class ClienteCuentaCorrienteMovimiento
    {
        public ClienteCuentaCorrienteMovimiento()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public int IdClienteCuentaCorriente { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdComprobante { get; set; }
        public string Concepto { get; set; } = null!;
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public DateTime? Vencimiento { get; set; }
        public int? IdTipoMovimiento { get; set; }

        public virtual ClienteCuentaCorriente IdClienteCuentaCorrienteNavigation { get; set; } = null!;
        public virtual Comprobante? IdComprobanteNavigation { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
