﻿using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Numero { get; set; }
        public int? Resultado { get; set; }
        public string? Fecha { get; set; }
    }
}
