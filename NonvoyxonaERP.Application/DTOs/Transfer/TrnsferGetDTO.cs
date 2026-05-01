using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Transfer
{
    public class TrnsferGetDTO : BaseDTO
    {

        public int TochkaId { get; set; }
        public string TochkaNomi { get; set; } = string.Empty;
        public int XodimId { get; set; }
        public string XodimFIO { get; set; } = string.Empty;
        public string Holat { get; set; } = string.Empty;
        public string? Izoh { get; set; }
        public DateTime YaratilganVaqt { get; set; }
        public List<TransferQatorGetDTO> Qatorlar { get; set; } = new();
    }

    public class TransferQatorGetDTO : BaseDTO
    {
        public int MaxsulotId { get; set; }
        public string MaxsulotNomi { get; set; } = string.Empty;
        public int YuborilganMiq { get; set; }
        public int QabulMiqdor { get; set; }
    }
}
