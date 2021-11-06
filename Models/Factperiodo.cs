using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Factperiodo
    {
        public Factperiodo()
        {
            Farmacia = new HashSet<Farmacia>();
        }

        public int Idperiodo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Farmacia> Farmacia { get; set; }
    }
}
