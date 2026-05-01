using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Davomat
{
    public class DavomatGetDTO : BaseDTO
    {
        public int XodimId { get; set; }
        public string XodimFIO { get; set; } = string.Empty;
        public DateTime Sana { get; set; }
        public TimeSpan? KeldiVaqt { get; set; }
        public TimeSpan? KetdiVaqt { get; set; }
        public string Smena { get; set; } = string.Empty;
        public string? Izoh { get; set; }
    }
}
