using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class DetRemito
    {
        public string? NroRemito { get; set; }
        public string? Codigo { get; set; }
        public double? Cantidad { get; set; }
        public double? ImporteUnitario { get; set; }
        public double? ImporteTotal { get; set; }
        public string? Detalle { get; set; }
        public double? Iva { get; set; }
        public string? Tipo { get; set; }
    }
}
