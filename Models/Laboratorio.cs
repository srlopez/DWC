using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Laboratorio
    {
        public Laboratorio()
        {
            Pedlineas = new HashSet<Pedlinea>();
            Precios = new HashSet<Precio>();
        }

        public string Idlaboratorio { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pedlinea> Pedlineas { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
    }
}
