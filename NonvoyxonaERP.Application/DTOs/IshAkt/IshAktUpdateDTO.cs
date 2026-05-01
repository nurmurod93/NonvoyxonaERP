using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.IshAkt
{
    public class IshAktUpdateDTO : BaseDTO
    {
        public string Smena { get; set; } = string.Empty;
        public string Holat { get; set; } = string.Empty;
    }
}
