using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonvoyxonaERP.Domain.Enums;

namespace NonvoyxonaERP.Application.DTOs.Xodim
{
    public class XodimGetDTO : BaseDTO
    {
        public string FIO { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string Lavozimi { get; set; } = string.Empty;
        public MaoshTuri MaoshiTuri { get; set; } = MaoshTuri.Fiksir;
        public decimal AsosiyMaoshi { get; set; }
        public decimal IshbayNarxi { get; set; }
        public DateTime IshgaKirgan { get; set; }
        public bool Aktiv { get; set; }
    }
}
