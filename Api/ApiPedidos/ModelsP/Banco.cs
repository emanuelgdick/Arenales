using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Banco
    {
        public Banco()
        {
            Cheques = new HashSet<Cheque>();
            Tarjeta = new HashSet<Tarjetum>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual ICollection<Tarjetum> Tarjeta { get; set; }
    }
}
