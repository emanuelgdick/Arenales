using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Wish
{
    public long Id { get; set; }

    public long IdUsuario { get; set; }

    [ForeignKey("IdUsuario")] // O especifica la propiedad de navegación si es necesario
    
    public Usuario? Usuario { get; set; }
    public long IdProducto { get; set; }

    [ForeignKey("IdProducto")] // O especifica la propiedad de navegación si es necesario
    
    public Producto? Producto { get; set; }
}
