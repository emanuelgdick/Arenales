using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
}
