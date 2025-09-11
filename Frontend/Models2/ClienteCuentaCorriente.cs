using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class ClienteCuentaCorriente
    {
        public ClienteCuentaCorriente()
        {
            ClienteCuentaCorrienteMovimientos = new HashSet<ClienteCuentaCorrienteMovimiento>();
        }

        public int Id { get; set; }
        public long IdCliente { get; set; }
        public int EstadoCuentaCorriente { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ClienteCuentaCorrienteMovimiento> ClienteCuentaCorrienteMovimientos { get; set; }
    }
}
