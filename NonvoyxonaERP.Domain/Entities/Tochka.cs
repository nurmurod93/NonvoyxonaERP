using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Tochka : BaseEntity
    {
        public string Nomi { get; set; } = string.Empty;
        public string? Manzil { get; set; }
        public int? MasulId { get; set; }
        public Xodim? Masul { get; set; }
        public string? Telefon { get; set; }
        public bool Aktiv { get; set; } = true;

        public ICollection<Transfer> Transferlar { get; set; } = new List<Transfer>();
        public ICollection<Savdo> Savdolar { get; set; } = new List<Savdo>();
    }
}
