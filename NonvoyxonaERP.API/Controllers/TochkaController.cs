using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Tochka;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TochkaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TochkaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TochkaGetDTO>>> GetAll()
        {
            return await _context.Tochkalar
                .Include(t => t.Masul).Select(t => new TochkaGetDTO
                {
                    Id = t.Id,
                    Nomi = t.Nomi,
                    Manzil = t.Manzil,
                    MasulId = t.MasulId,
                    MasulFIO = t.Masul != null ? t.Masul.FIO : null,
                    Telefon = t.Telefon,
                    Aktiv = t.Aktiv,
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TochkaGetDTO>> GetById(int id)
        {
            var t = await _context.Tochkalar
                .Include(t => t.Masul)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (t == null)
                return NotFound();

            return new TochkaGetDTO
            {
                Id = t.Id,
                Nomi = t.Nomi,
                Manzil = t.Manzil,
                MasulId = t.MasulId,
                MasulFIO = t.Masul != null ? t.Masul.FIO : null,
                Telefon = t.Telefon,
                Aktiv = t.Aktiv,
            };
        }

        [HttpPost]
        public async Task<ActionResult<TochkaGetDTO>> Create(TochkaCreateDTO tochkaCreateDTO)
        {
            var tochka = new Tochka
            {
                Nomi = tochkaCreateDTO.Nomi,
                Manzil = tochkaCreateDTO.Manzil,
                MasulId = tochkaCreateDTO.MasulId,
                Telefon = tochkaCreateDTO.Telefon,
                Aktiv = true,
                Yaratilganvaqt = DateTime.Now,
            };
            _context.Tochkalar.Add(tochka);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tochka.Id },
                new TochkaGetDTO
                {
                    Id = tochka.Id,
                    Nomi = tochka.Nomi,
                    Manzil = tochka.Manzil,
                    MasulId = tochka.MasulId,
                    Telefon = tochka.Telefon,
                    Aktiv = tochka.Aktiv,
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TochkaUpdateDTO tochkaUpdateDTO)
        {
            if (id != tochkaUpdateDTO.Id)
                return BadRequest();
            var tochka = await _context.Tochkalar.FindAsync(id);
            if (tochka == null)
                return NotFound();
            tochka.Nomi = tochkaUpdateDTO.Nomi;
            tochka.Manzil = tochkaUpdateDTO.Manzil;
            tochka.MasulId = tochkaUpdateDTO.MasulId;
            tochka.Telefon = tochkaUpdateDTO.Telefon;
            tochka.Aktiv = tochkaUpdateDTO.Aktiv;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tochka = await _context.Tochkalar.FindAsync(id);
            if (tochka == null)
                return NotFound();
            _context.Tochkalar.Remove(tochka);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
