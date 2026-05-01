using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Davomat
{
    public class DavomatUpdateDTO : BaseDTO
    {
        public TimeSpan? KeldiVaqt { get; set; }
        public TimeSpan? KetdiVaqt { get; set; }
        public string Smena { get; set; } = string.Empty;
        public string? Izoh { get; set; }
    }
}
