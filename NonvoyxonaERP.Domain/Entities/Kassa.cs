using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class Kassa : BaseEntity
    {
        public string Nomi { get; set; } = string.Empty;
        public string Turi { get; set; } = "Naqt";
        public decimal Qoldiq { get; set; }
        public bool Aktiv { get; set; } = true;
    }
}
