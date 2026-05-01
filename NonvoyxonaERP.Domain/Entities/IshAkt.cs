using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class IshAkt : BaseEntity
    {
        public int XodimId { get; set; }
        public Xodim Xodim { get; set; } = null!;
        public DateTime Sana { get; set; } = DateTime.Now;
        public string Smena { get; set; } = "Kunduzi";
        public string Holat { get; set; } = "Ochiq";

        public ICollection<IshAktQator> Qatorlar { get; set; } = new List<IshAktQator>();
    }
}
