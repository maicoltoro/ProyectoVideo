using System;
using System.Collections.Generic;

namespace ApiVideo.Models.STI
{
    public partial class Agente
    {
        public string Documento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
