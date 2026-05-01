using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Taminotchi;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaminotchiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaminotchiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaminotchiGetDTO>>> GetAll()
        {
            return await _context.Taminotchilar
                .Select(t => new TaminotchiGetDTO
                {
                    Id = t.Id,
                    Nomi = t.Nomi,
                    Telefon = t.Telefon,
                    Manzil = t.Manzil,
                    Qarz = t.Qarz,
                    Aktiv = t.Aktiv
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaminotchiGetDTO>> GetById(int id)
        {
            var t = await _context.Taminotchilar.FindAsync(id);
            if (t == null)
                return NotFound();
            return new TaminotchiGetDTO
            {
                Id = t.Id,
                Nomi = t.Nomi,
                Telefon = t.Telefon,
                Manzil = t.Manzil,
                Qarz = t.Qarz,
                Aktiv = t.Aktiv
            };
        }

        [HttpPost]
        public async Task<ActionResult<TaminotchiGetDTO>> Create(TaminotchiCreateDTO taminotchiCreateDTO)
        {
            var taminotchi = new Taminotchi
            {
                Nomi = taminotchiCreateDTO.Nomi,
                Telefon = taminotchiCreateDTO.Telefon,
                Manzil = taminotchiCreateDTO.Manzil,
                Qarz = 0,
                Aktiv = true,
                Yaratilganvaqt = DateTime.Now
            };
            _context.Taminotchilar.Add(taminotchi);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = taminotchi.Id },
               new TaminotchiGetDTO
               {
                   Id = taminotchi.Id,
                   Nomi = taminotchi.Nomi,
                   Telefon = taminotchi.Telefon,
                   Manzil = taminotchi.Manzil,
                   Qarz = taminotchi.Qarz,
                   Aktiv = taminotchi.Aktiv
               });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaminotchiUpdateDTO taminotchiUpdateDTO)
        {
            var taminotchi = await _context.Taminotchilar.FindAsync(id);
            if (taminotchi == null)
                return NotFound();
            taminotchi.Nomi = taminotchiUpdateDTO.Nomi;
            taminotchi.Telefon = taminotchiUpdateDTO.Telefon;
            taminotchi.Manzil = taminotchiUpdateDTO.Manzil;
            taminotchi.Qarz = taminotchiUpdateDTO.Qarz;
            taminotchi.Aktiv = taminotchiUpdateDTO.Aktiv;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taminotchi = await _context.Taminotchilar.FindAsync(id);
            if (taminotchi == null)
                return NotFound();

            _context.Taminotchilar.Remove(taminotchi);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
