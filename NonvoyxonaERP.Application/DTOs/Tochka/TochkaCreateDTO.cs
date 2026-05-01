using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Application.DTOs.Tochka
{
    public class TochkaCreateDTO 
    {
        public string Nomi { get; set; } = string.Empty;
        public string? Manzil { get; set; }
        public int? MasulId { get; set; }
        public string? Telefon { get; set; }
    }
}
