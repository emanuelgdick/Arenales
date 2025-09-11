using System;
using System.Collections.Generic;

namespace Frontend.Models;

public partial class PuntoVentum
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Numero { get; set; }

    public string Cuit { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string? PathCertificado { get; set; }

    public string? Token { get; set; }

    public string? Sign { get; set; }

    public string? ExpirationTime { get; set; }

    public string? TokenPad { get; set; }

    public string? SignPad { get; set; }

    public string? ExpirationTimePad { get; set; }

    public long? IdCondicionIva { get; set; }

    public string? FechaInicioAct { get; set; }

    public string? De { get; set; }

    public string? PswCertificado { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
