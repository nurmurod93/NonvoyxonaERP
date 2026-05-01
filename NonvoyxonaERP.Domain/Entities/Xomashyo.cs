using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Xomashyo : BaseEntity
    {
        public string Nomi { get; set; } = string.Empty;
        public decimal Miqdori { get; set; }
        public string OlchovBirligi { get; set; } = "kg";
        public decimal MinDaraja { get; set; }
        public decimal Narxi { get; set; }
        public ICollection<Retsept> Retseptlar { get; set; } = new List<Retsept>();
    }
}
