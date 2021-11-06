using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Pedlineas = new HashSet<Pedlinea>();
        }

        public int Idpedido { get; set; }
        public string Idfarmacia { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }
        public string Idestado { get; set; }
        public Guid? Idfactura { get; set; }

        public virtual Pedestado IdestadoNavigation { get; set; }
        public virtual Farmacia IdfarmaciaNavigation { get; set; }
        public virtual ICollection<Pedlinea> Pedlineas { get; set; }
    }
}
