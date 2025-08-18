using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            ComprobanteCompras = new HashSet<ComprobanteCompra>();
        }

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

        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
    }
}
