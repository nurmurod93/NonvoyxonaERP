using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Savdo : BaseEntity
    {
        public int? TochkaId { get; set; }
        public Tochka? Tochka { get; set; }

        public int XodimId { get; set; }
        public Xodim Xodim { get; set; } = null!;

        public decimal JamiSumma { get; set; }
        public string TolovTuri { get; set; } = "Naqd";
        public string Holat { get; set; } = "Yakunlangan";

        public ICollection<SavdoQator> Qatorlar { get; set; } = new List<SavdoQator>();
    }
}
