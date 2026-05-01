using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class SavdoQator : BaseEntity
    {
        public int SavdoId { get; set; }
        public Savdo Savdo { get; set; } = null!;

        public int MaxsulotId { get; set; }
        public Maxsulot Maxsulot { get; set; } = null!;

        public int Miqdor { get; set; }
        public decimal Narx { get; set; }
        public decimal JamiNarx => Miqdor * Narx;
    }
}
