using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Medfamilia
    {
        public Medfamilia()
        {
            Medicamentos = new HashSet<Medicamento>();
        }

        public string Idfamilia { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
