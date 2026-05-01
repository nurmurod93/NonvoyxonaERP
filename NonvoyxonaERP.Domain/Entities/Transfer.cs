using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Transfer : BaseEntity
    {
        public int TochkaId { get; set; }
        public Tochka Tochka { get; set; } = null!;

        public int XodimId { get; set; }
        public Xodim Xodim { get; set; } = null!;

        public string Holat { get; set; } = "Yolda";
        public string? Izoh { get; set; }

        public ICollection<TransferQator> Qatorlar { get; set; } = new List<TransferQator>();
    }
}
