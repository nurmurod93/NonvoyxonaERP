using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonvoyxonaERP.Domain.Enums;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Xodim : BaseEntity
    {
        public string FIO { get; set; } = string.Empty;
        public string? Telefon { get; set; }
        public string Lavozimi { get; set; } = string.Empty;
        public MaoshTuri MaoshiTuri { get; set; } = MaoshTuri.Fiksir;
        public decimal AsosiyMaoshi { get; set; }
        public decimal IshbayNarxi { get; set; }
        public DateTime IshgaKirgan { get; set; } = DateTime.Now;
        public bool Aktive { get; set; } = true;

        public ICollection<Davomat> Davomatlar { get; set; } = new List<Davomat>();
        public ICollection<Maosh> Maoshlar { get; set; } = new List<Maosh>();
        public ICollection<IshAkt> IshAktlar { get; set; } = new List<IshAkt>();
    }
}
