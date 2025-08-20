using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Banco
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cheque> Cheques { get; set; } = new List<Cheque>();

    public virtual ICollection<Tarjetum> Tarjeta { get; set; } = new List<Tarjetum>();
}
