using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Davomat
{
    public class DavomatCreateDTO
    {
        public int XodimId { get; set; }
        public DateTime Sana { get; set; } = DateTime.Today;
        public TimeSpan? KeldiVaqt { get; set; }
        public TimeSpan? KetdiVaqt { get; set; }
        public string Smena { get; set; } = "Kunduz";
        public string? Izoh { get; set; }
    }
}
