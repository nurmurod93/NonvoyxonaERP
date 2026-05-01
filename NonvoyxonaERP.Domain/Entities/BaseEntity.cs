using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonvoyxonaERP.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Yaratilganvaqt { get; set; } = DateTime.Now;
    }
}
