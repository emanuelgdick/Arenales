using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPedidos.Models
{
    public partial class TipoCliente
    {
        public TipoCliente()
        {
            ClienteBonificacions = new HashSet<ClienteBonificacion>();
            Clientes = new HashSet<Cliente>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ClienteBonificacion> ClienteBonificacions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
