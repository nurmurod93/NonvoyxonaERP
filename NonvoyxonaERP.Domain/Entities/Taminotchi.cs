using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Taminotchi : BaseEntity
    {
        public string Nomi { get; set; } = string.Empty;
        public string Manzil { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public decimal Qarz { get; set; }
        public bool Aktiv { get; set; } = true;
    }
}
