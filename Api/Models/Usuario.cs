using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public partial class Usuario
{
    public long Id { get; set; }
    public long? IdLocalidad { get; set; }

    [ForeignKey("IdLocalidad")]
    public Localidad? Localidad { get; set; }
    public string ApeyNom { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    //public string Observaciones { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Carrito>? Carritos { get; set; } = new List<Carrito>();
    public virtual ICollection<Wish>? Wishes { get; set; } = new List<Wish>();
}
