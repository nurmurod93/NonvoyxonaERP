using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Kassa
{
    public class KassaCreateDTO
    {
        public string Nomi { get; set; } = string.Empty;
        public string Turi { get; set; } = string.Empty;
        public decimal Qoldiq { get; set; }
    }
}
