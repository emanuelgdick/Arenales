using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Talle
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Numero { get; set; }

    [JsonIgnore]
    public virtual ICollection<Producto>? Productos { get; set; } = new List<Producto>();
}
