using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Farmacia
    {
        public Farmacia()
        {
            Facturas = new HashSet<Factura>();
            Pedidos = new HashSet<Pedido>();
        }

        public string Idfarmacia { get; set; }
        public string Nombre { get; set; }
        public string Poblacion { get; set; }
        public int Idperiodo { get; set; }
        public DateTime? Ultfactura { get; set; }

        public virtual Factperiodo IdperiodoNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
