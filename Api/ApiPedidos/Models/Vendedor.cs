using System;
using System.Collections.Generic;

namespace ApiPedidos.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            CajaMovimientos = new HashSet<CajaMovimiento>();
            //Carritos = new HashSet<Carrito>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Calle { get; set; }
        public string Legajo { get; set; } = null!;
        public int? Numero { get; set; }
        public string? Cuit { get; set; }
        public string? Depto { get; set; }
        public string? Email { get; set; }
        public int? Piso { get; set; }
        public string? TelefonoFijo { get; set; }
        public string? TelefonoMovil { get; set; }
        public string? Torre { get; set; }
        public string? Observaciones { get; set; }

        public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
    }
}
