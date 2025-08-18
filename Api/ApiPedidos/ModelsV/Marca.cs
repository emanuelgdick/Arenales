using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPedidos.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Imagen { get; set; }

        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
