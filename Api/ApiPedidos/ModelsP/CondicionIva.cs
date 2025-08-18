using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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


        [JsonIgnore]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
