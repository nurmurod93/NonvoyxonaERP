using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Transfer
{
    public class TransferCreateDTO
    {
        public int TochkaId { get; set; }
        public int XodimId { get; set; }
        public string? Izoh { get; set; }
        public List<TransferQatorCreateDTO> Qatorlar { get; set; } = new();
    }

    public class TransferQatorCreateDTO
    {
        public int MaxsulotId { get; set; }
        public int YuborilganMiq { get; set; }
    }
}
