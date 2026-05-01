using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Maxsulot
{
    public class MaxsulotCreateDTO
    {
        public string Nomi { get; set; } = string.Empty;
        public string Kategoryasi { get; set; } = string.Empty;
        public decimal Narxi { get; set; }
        public string OlchovBirligi { get; set; } = "dona";
    }
}
