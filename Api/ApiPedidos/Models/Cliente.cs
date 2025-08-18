using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPedidos.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Carritos = new HashSet<Carrito>();
            ClienteCuentaCorrientes = new HashSet<ClienteCuentaCorriente>();
            Comprobantes = new HashSet<Comprobante>();
            Movimientos = new HashSet<Movimiento>();
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
        public long IdCondicionIva { get; set; }
        public string? RazonSocial { get; set; }
        public string? CodCliente { get; set; }
        public long? IdTipoCliente { get; set; }
        public string? Imagen { get; set; }

        [JsonIgnore]
        public virtual CondicionIva oCondicionIva { get; set; } = null!;
        [JsonIgnore]
        public virtual TipoCliente? oTipoCliente { get; set; }
        [JsonIgnore]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClienteCuentaCorriente> ClienteCuentaCorrientes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
