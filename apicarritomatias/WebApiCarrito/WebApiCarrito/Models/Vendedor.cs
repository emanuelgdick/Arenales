using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Vendedor
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string Legajo { get; set; } = null!;

    public long? IdSucursal { get; set; }

    public string? Usuario { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; } = new List<CajaMovimiento>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
