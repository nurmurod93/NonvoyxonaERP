using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.IshAkt
{
    public class IshAktGetDTO : BaseDTO
    {
        public DateTime Sana { get; set; }
        public int XodimId { get; set; }
        public string XodimFIO { get; set; } = string.Empty;
        public string Smena { get; set; } = string.Empty;
        public string Holat { get; set; } = string.Empty;
        public DateTime YaratilganVaqt { get; set; }
        public List<IshAktQatorGetDTO> Qatorlar { get; set; } = new();
    }

    public class IshAktQatorGetDTO : BaseDTO
    {
        public int MaxsulotId { get; set; }
        public string MaxsulotNomi { get; set; } = string.Empty;
        public int RejalashMiqdor { get; set; }
        public int HaqiqiyMiqdor { get; set; }
        public int BrakMiqdor { get; set; }
    }
}
