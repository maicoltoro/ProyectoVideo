using System;
using System.Collections.Generic;

namespace ApiVideo.Models.STI
{
    public partial class GuardarVideo
    {
        public int Id { get; set; }
        public string NombreVideo { get; set; } = null!;
        public string Fecha { get; set; } = null!;
    }
}
