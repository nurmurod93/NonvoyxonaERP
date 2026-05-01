using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Maosh
{
    public class MaoshCreateDTO
    {
        public int XodimId { get; set; }
        public int Yil { get; set; } = DateTime.Now.Year;
        public int Oy { get; set; } = DateTime.Now.Month;
        public decimal HisoblanganMaosh { get; set; }
        public decimal Avans { get; set; }
        public decimal Shtraf { get; set; }
        public decimal Mukofot { get; set; }
    }
}
