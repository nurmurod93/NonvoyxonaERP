using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Transfer
{
    public class TransferUpdateDTO : BaseDTO
    {
        public string Holat { get; set; } = string.Empty;
        public string? Izoh { get; set; }
    }
}
