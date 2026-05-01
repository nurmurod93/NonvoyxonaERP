using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Maosh
{
    public class MaoshGetDTO : BaseDTO
    {
        public int XodimId { get; set; }
        public string XodimFIO { get; set; } = string.Empty;
        public int Yil { get; set; }
        public int Oy { get; set; }
        public decimal HisoblanganMaosh { get; set; }
        public decimal Avans { get; set; }
        public decimal Shtraf { get; set; }
        public decimal Mukofot { get; set; }
        public decimal Tolangan { get; set; }
        public decimal QoldiqMaosh => HisoblanganMaosh + Mukofot - Shtraf - Avans - Tolangan;
        public DateTime? TolashSana { get; set; }
    }
}
