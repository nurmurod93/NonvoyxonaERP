using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Xarajat : BaseEntity
    {
        public int KassaId { get; set; }
        public Kassa Kassa { get; set; } = null!;

        public int? XodimId { get; set; }
        public Xodim? Xodim { get; set; }

        public string Kategorya { get; set; } = string.Empty;
        public decimal Summa { get; set; }
        public string Izoh { get; set; }
    }
}
