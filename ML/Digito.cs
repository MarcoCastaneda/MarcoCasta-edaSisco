using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Digito
    {
        public int IdDigito { get; set; }
        public int Numero { get; set; }
        public int Resultado { get; set; }
        public string Fecha { get; set; }
        public List<object> Digitos { get; set; }
        public int IdUsuario { get; set; }
        public ML.Usuario usuario { get; set; }
        
    }
}
