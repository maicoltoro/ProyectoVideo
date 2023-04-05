using System;
using System.Collections.Generic;

namespace ApiVideo.Models.STI
{
    public partial class Asesor
    {
        public int IdAsesor { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Celular { get; set; }
    }
}
