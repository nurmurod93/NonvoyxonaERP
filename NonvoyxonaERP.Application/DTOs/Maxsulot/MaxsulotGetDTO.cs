using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Maxsulot
{
    public class MaxsulotGetDTO : BaseDTO
    {
        public string Nomi { get; set; } = string.Empty;
        public string Kategoryasi { get; set; } = string.Empty;
        public decimal Narxi { get; set; }
        public string Olchovbirligi { get; set; } = string.Empty;
        public bool Aktiv { get; set; }
    }
}
