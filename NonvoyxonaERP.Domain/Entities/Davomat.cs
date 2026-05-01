using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Davomat : BaseEntity
    {
        public int XodimId { get; set; }
        public Xodim Xodim { get; set; } = null!;
        public DateTime Sana { get; set; } = DateTime.Now;
        public TimeSpan? KeldiVaqt { get; set; }
        public TimeSpan? KetdiVaqt { get; set; }
        public string Smena { get; set; } = "Kunduz";
        public string? Izoh { get; set; }
    }
}
