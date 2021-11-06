using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Pedestado
    {
        public Pedestado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Idestado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
