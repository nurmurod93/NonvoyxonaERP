using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Savdo
{
    public class SavdoUpdateDTO : BaseDTO
    {
        public string TolovTuri { get; set; } = string.Empty;
        public string Holat { get; set; } = string.Empty;
    }
}
