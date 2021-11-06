using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            Pedlineas = new HashSet<Pedlinea>();
            Precios = new HashSet<Precio>();
        }

        public string Idfamilia { get; set; }
        public string Idmedicamento { get; set; }
        public string Nombre { get; set; }
        public string Prescripcion { get; set; }
        public string Posoligia { get; set; }
        public bool? Generico { get; set; }

        public virtual Medfamilia IdfamiliaNavigation { get; set; }
        public virtual ICollection<Pedlinea> Pedlineas { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
    }
}
