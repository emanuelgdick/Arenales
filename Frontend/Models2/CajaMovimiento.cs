using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class CajaMovimiento
    {
        public int Id { get; set; }
        public int IdCaja { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int IdTipoMovimientoCaja { get; set; }
        public int? IdVendedor { get; set; }

        public virtual Caja IdCajaNavigation { get; set; } = null!;
        public virtual TipoMovimientoCaja IdTipoMovimientoCajaNavigation { get; set; } = null!;
        public virtual Vendedor? IdVendedorNavigation { get; set; }
    }
}
