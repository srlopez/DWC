using System;
using System.Collections.Generic;

#nullable disable

namespace dwc.Models
{
    public partial class Pedlinea
    {
        public int Idpedido { get; set; }
        public string Idmedicamento { get; set; }
        public string Idlaboratorio { get; set; }
        public int Cantidad { get; set; }
        public decimal? Precio { get; set; }

        public virtual Laboratorio IdlaboratorioNavigation { get; set; }
        public virtual Medicamento IdmedicamentoNavigation { get; set; }
        public virtual Pedido IdpedidoNavigation { get; set; }
    }
}
