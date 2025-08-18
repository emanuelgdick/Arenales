using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Veterinarium
    {
        public double? Código { get; set; }
        public string? Proveedor { get; set; }
        public string? Sección { get; set; }
        public string? Rubro { get; set; }
        public string? Marca { get; set; }
        public string? Producto { get; set; }
        public string? Características { get; set; }
        public double? PesoKg { get; set; }
        public string? Unidad { get; set; }
        public double? PCompra { get; set; }
        public double? Margen { get; set; }
        public double? PLista { get; set; }
        public double? CEfectivo { get; set; }
        public double? Utilidad { get; set; }
        public double? CostoUnid { get; set; }
        public double? MargenFraccionado { get; set; }
        public double? UtilidadFracc { get; set; }
        public double? PListaFrac { get; set; }
        public double? PFracEfec { get; set; }
        public string? Unidad2 { get; set; }
    }
}
