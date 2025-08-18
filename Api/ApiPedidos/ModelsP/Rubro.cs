using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPedidos.Models
{
    public partial class Rubro
    {
        public Rubro()
        {
            ClienteBonificacions = new HashSet<ClienteBonificacion>();
            Productos = new HashSet<Producto>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Codigo { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ClienteBonificacion> ClienteBonificacions { get; set; }

        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
