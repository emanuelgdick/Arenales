using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Manual { get; set; }
        public int? Signo { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
