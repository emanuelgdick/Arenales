using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class TipoComprobante
    {
        public TipoComprobante()
        {
            ComprobanteCompras = new HashSet<ComprobanteCompra>();
            Comprobantes = new HashSet<Comprobante>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Signo { get; set; }
        public string Letra { get; set; } = null!;
        public bool EsFiscal { get; set; }

        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
