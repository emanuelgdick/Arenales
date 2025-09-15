using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class Usuario
{
    public long Id { get; set; }
    public string ApeyNom { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Carrito>? Carritos { get; set; } = new List<Carrito>();

}
