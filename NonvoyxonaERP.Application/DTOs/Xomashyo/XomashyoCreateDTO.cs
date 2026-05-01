using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Xomashyo
{
    public class XomashyoCreateDTO
    {
        public string Nomi { get; set; } = string.Empty;
        public decimal Miqdori { get; set; }
        public string OlchovBirligi { get; set; } = "kg";
        public decimal MinDaraja { get; set; }
        public decimal Narxi { get; set; }
    }
}
