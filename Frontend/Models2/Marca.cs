using System;
using System.Collections.Generic;

namespace Frontend.Models
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

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
