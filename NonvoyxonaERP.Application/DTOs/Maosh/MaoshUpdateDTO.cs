using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Maosh
{
    public class MaoshUpdateDTO : BaseDTO
    {
        public decimal Avans { get; set; }
        public decimal Shtraf { get; set; }
        public decimal Mukofot { get; set; }
        public decimal Tolangan { get; set; }
        public DateTime? TolashSana { get; set; }
    }
}
