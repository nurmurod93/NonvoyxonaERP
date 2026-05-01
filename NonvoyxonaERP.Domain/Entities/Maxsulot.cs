using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Maxsulot : BaseEntity
    {
        public string Nomi { get; set; }
        public string Kategoryasi { get; set; }
        public decimal Narxi { get; set; }
        public string OlchovBirligi { get; set; } = "dona";
        public bool Aktiv { get; set; } = true;
        public ICollection<Retsept> Retseptlar { get; set; } = new List<Retsept>();
        public ICollection<SavdoQator> SavdoQatorlar { get; set; } = new List<SavdoQator>();
        public ICollection<IshAktQator> IsAktQatorlar { get; set; } = new List<IshAktQator>();
    }
}
