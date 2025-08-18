using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class TipoMovimientoCaja
    {
        public TipoMovimientoCaja()
        {
            CajaMovimientos = new HashSet<CajaMovimiento>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Signo { get; set; }

        public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; }
    }
}
