using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Digito
    {
        public int IdDigito { get; set; }
        public int? Numero { get; set; }
        public int? Resultado { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
