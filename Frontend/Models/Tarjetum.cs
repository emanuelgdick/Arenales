using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public partial class Tarjetum
    {
        public Tarjetum()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public int IdBanco { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual Banco IdBancoNavigation { get; set; } = null!;
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
