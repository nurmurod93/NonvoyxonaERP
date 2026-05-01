using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Tochka
{
    public class TochkaGetDTO : BaseDTO
    {
        public string Nomi { get; set; }
        public string? Manzil { get; set; }
        public int? MasulId { get; set; }
        public string? MasulFIO { get; set; }
        public string? Telefon { get; set; }
        public bool Aktiv { get; set; }
    }
}
