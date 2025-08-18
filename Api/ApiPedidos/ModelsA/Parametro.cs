using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Parametro
    {
        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Valor { get; set; } = null!;
    }
}
