using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class ProveedorCuentaCorrienteMovimiento
    {
        public int Id { get; set; }
        public int IdProveedorCuentaCorriente { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdComprobante { get; set; }
        public string Concepto { get; set; } = null!;
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public DateTime? Vencimiento { get; set; }
        public int? IdTipoMovimiento { get; set; }
    }
}
