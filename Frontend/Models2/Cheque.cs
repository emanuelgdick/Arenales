using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Cheque
    {
        public int Id { get; set; }
        public int? IdBanco { get; set; }
        public string? Sucursal { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaCobro { get; set; }
        public bool? EsPropio { get; set; }
        public decimal? ImporteCheque { get; set; }
        public long? IdPago { get; set; }

        public virtual Banco? IdBancoNavigation { get; set; }
    }
}
