using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Retsept : BaseEntity
    {
        public int MaxsulotId { get; set; }
        public Maxsulot Maxsulot { get; set; } = null!;
        public int XomashyoId { get; set; }
        public Xomashyo Xomashyo { get; set; } = null!;
        public decimal Miqdori { get; set; }
        public string OlchovBirligi { get; set; } = "kg";
    }
}
