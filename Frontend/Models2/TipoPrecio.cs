using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class TipoPrecio
    {
        public string? Codigo { get; set; }
        public decimal? CodTipo { get; set; }
        public string? Detalle { get; set; }
        public double? Costo { get; set; }
        public double? Ganancia { get; set; }
        public double? ImporteSinIva { get; set; }
        public double? Iva { get; set; }
        public double? Importe { get; set; }
        public double? Stock { get; set; }
        public double? StockMinimo { get; set; }
        public string? Tipo { get; set; }
        public double? Cantidad { get; set; }
        public int? IdMarca { get; set; }
        public decimal? Tasa { get; set; }
    }
}
