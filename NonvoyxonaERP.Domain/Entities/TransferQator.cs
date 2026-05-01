using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class TransferQator : BaseEntity
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; } = null!;

        public int MaxsulotId { get; set; }
        public Maxsulot Maxsulot { get; set; } = null!;

        public int YuborilganMiq { get; set; }
        public int QabulMiqdor { get; set; }
    }
}
