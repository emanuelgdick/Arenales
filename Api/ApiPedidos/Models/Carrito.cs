using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPedidos.Models
{
    public partial class Carrito
    {
        public Carrito()
        {
            CarritoItems = new HashSet<CarritoItem>();
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Nro { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Vendedor IdVendedorNavigation { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<CarritoItem> CarritoItems { get; set; }
    }
}
