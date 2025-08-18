using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class CondicionIva
    {
        public CondicionIva()
        {
            Clientes = new HashSet<Cliente>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
