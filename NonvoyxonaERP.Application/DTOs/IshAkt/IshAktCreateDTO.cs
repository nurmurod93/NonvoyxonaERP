using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.IshAkt
{
    public class IshAktCreateDTO
    {
        public DateTime Sana { get; set; } = DateTime.Today;
        public int XodimId { get; set; }
        public string Smena { get; set; } = "Kunduz";
        public List<IshAktQatorCreateDTO> Qatorlar { get; set; } = new();
    }

    public class IshAktQatorCreateDTO
    {
        public int MaxsulotId { get; set; }
        public int RejalashMiqdor { get; set; }
        public int HaqiqiyMiqdor { get; set; }
        public int BrakMiqdor { get; set; }
    }

}
