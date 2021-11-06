using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Precio
    {
        public string Idmedicamento { get; set; }
        public string Idlaboratorio { get; set; }
        public decimal? Precio1 { get; set; }
        public decimal? Coste { get; set; }

        public virtual Laboratorio IdlaboratorioNavigation { get; set; }
        public virtual Medicamento IdmedicamentoNavigation { get; set; }
    }
}
