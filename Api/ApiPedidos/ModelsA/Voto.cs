using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Voto
    {
        public long Id { get; set; }
        public string Documento { get; set; } = null!;
        public int Opcion { get; set; }
    }
}
