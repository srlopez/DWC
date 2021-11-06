using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Factura
    {
        public Guid Idfactura { get; set; }
        public string Idfarmacia { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Farmacia IdfarmaciaNavigation { get; set; }
    }
}
