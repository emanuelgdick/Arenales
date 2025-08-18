using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Cai
    {
        public long Id { get; set; }
        public long NumeroDesde { get; set; }
        public long NumeroHasta { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
