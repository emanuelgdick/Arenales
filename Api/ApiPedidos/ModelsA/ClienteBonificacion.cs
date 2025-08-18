using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class ClienteBonificacion
    {
        public long Id { get; set; }
        public long? IdRubro { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; } = null!;
        public long IdTipoCliente { get; set; }

        public virtual Rubro? IdRubroNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteNavigation { get; set; } = null!;
    }
}
