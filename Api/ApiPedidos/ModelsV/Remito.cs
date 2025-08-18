using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Remito
    {
        public DateTime? Fecha { get; set; }
        public string? NroRemito { get; set; }
        public string? TipoRemito { get; set; }
        public double? CodCliente { get; set; }
        public double? ImporteTotal { get; set; }
        public string? NroFact { get; set; }
        public string? TipoFact { get; set; }
        public string? Retirado { get; set; }
    }
}
