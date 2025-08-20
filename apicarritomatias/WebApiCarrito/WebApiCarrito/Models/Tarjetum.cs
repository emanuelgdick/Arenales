using System;
using System.Collections.Generic;

namespace WebApiCarrito.Models;

public partial class Tarjetum
{
    public int Id { get; set; }

    public int IdBanco { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Cuit { get; set; }

    public string? Email { get; set; }

    public string? Observaciones { get; set; }

    public string? PathCertificado { get; set; }

    public long? IdCondicionIva { get; set; }

    public int? PuntoVenta { get; set; }

    public string? FechaInicioActividades { get; set; }

    public string? Sign { get; set; }

    public string? Token { get; set; }

    public string? ExpirationTime { get; set; }

    public string? PassCert { get; set; }

    public bool? Test { get; set; }

    public string? PathImagen { get; set; }

    public virtual Banco IdBancoNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
