using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Kassa
{
    public class KassaUpdateDTO : BaseDTO
    {
        public string Nomi { get; set; } = string.Empty;
        public string Turi { get; set; } = string.Empty;
        public decimal Qoldiq { get; set; }
        public bool Aktiv { get; set; }
    }
}
