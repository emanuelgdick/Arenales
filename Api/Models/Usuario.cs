using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Usuario
{
        public long Id { get; set; }
        public string ApeyNom { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Carrito>? Carritos { get; set; } = new List<Carrito>();
        public virtual ICollection<Wish>? Wishes { get; set; } = new List<Wish>();
}
