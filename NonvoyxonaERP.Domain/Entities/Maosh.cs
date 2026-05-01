using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Maosh : BaseEntity
    {
        public int XodimId { get; set; }
        public Xodim Xodim { get; set; } = null!;

        public int Yil { get; set; }
        public int Oy { get; set; }
        public decimal HisoblanganMaosh { get; set; }
        public decimal Avans { get; set; }
        public decimal Shtraf { get; set; }
        public decimal Mukofot { get; set; }
        public decimal Tolangan { get; set; }
        public DateTime TolashSana { get; set; }
    }
}
