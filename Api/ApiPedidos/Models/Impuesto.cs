using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Impuesto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public decimal Alicuota { get; set; }
    }
}
