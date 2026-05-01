using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Savdo
{
    public class SavdoGetDTO : BaseDTO
    {
        public int? TochkaId { get; set; }
        public string? TochkaNomi { get; set; }
        public int XodimId { get; set; }
        public string XodimFIO { get; set; } = string.Empty;
        public decimal JamiSumma { get; set; }
        public string TolovTuri { get; set; } = string.Empty;
        public string Holat { get; set; } = string.Empty;
        public DateTime YaratilganVaqt { get; set; }
    }
}
