using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Frontend.Models;

public partial class Talle
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Numero { get; set; }
  
    [JsonIgnore]

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
