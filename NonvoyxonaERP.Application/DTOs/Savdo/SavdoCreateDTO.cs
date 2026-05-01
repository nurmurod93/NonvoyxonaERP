using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Savdo
{
    public class SavdoCreateDTO 
    {
        public int? TochkaId { get; set; }
        public int XodimId { get; set; }
        public string TolovTuri { get; set; } = "Naqd";
        public List<SavdoQatorCreateDTO> Qatorlar { get; set; } = new();
    }
    public class  SavdoQatorCreateDTO
    {
        public int MaxsulotId { get; set; }
        public int Miqdor { get; set; }
        public decimal Narx { get; set; }
    }
}
