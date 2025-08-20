using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Calle { get; set; }

    public int? Numero { get; set; }

    public string? Cuit { get; set; }

    public string? Depto { get; set; }

    public string? Email { get; set; }

    public int? Piso { get; set; }

    public string? TelefonoFijo { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? Torre { get; set; }

    public string? Observaciones { get; set; }

    public long IdCondicionIva { get; set; }

    public string? RazonSocial { get; set; }

    public string? CodCliente { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual CondicionIva IdCondicionIvaNavigation { get; set; } = null!;
}
