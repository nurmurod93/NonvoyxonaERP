using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class IshAktQator : BaseEntity
    {
        public int IshAktId { get; set; }
        public IshAkt IshAkt { get; set; } = null!;

        public int MaxsulotId { get; set; }
        public Maxsulot Maxsulot { get; set; } = null!;

        public int RejalashMiqdor { get; set; }
        public int HaqiqiyMiqdor { get; set; }
        public int BrakMiqdor { get; set; }
    }
}
