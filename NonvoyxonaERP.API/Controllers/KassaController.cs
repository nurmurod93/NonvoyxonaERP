using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Kassa;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KassaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public KassaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KassaGetDTO>>> GetAll()
        {
            return await _context.Kassalar
                .Select(k => new KassaGetDTO
                {
                    Id = k.Id,
                    Nomi = k.Nomi,
                    Turi = k.Turi,
                    Qoldiq = k.Qoldiq,
                    Aktiv = k.Aktiv
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KassaGetDTO>> GetById(int id)
        {
            var k = await _context.Kassalar.FindAsync(id);
            if(k == null) 
                return NotFound();

            return new KassaGetDTO
            {
                Id = k.Id,
                Nomi = k.Nomi,
                Turi = k.Turi,
                Qoldiq = k.Qoldiq,
                Aktiv = k.Aktiv
            };
        }

        [HttpPost]
        public async Task<ActionResult<KassaGetDTO>> Create(KassaCreateDTO kassaCreateDTO)
        {
            var kassa = new Kassa
            {
                Nomi = kassaCreateDTO.Nomi,
                Turi = kassaCreateDTO.Turi,
                Qoldiq = kassaCreateDTO.Qoldiq,
                Aktiv = true,
                Yaratilganvaqt = DateTime.Now
            };

            _context.Kassalar.Add(kassa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = kassa.Id }, 
                new KassaGetDTO
                {
                    Id = kassa.Id,
                    Nomi = kassa.Nomi,
                    Turi = kassa.Turi,
                    Qoldiq = kassa.Qoldiq,
                    Aktiv = kassa.Aktiv
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, KassaUpdateDTO kassaUpdateDTO)
        {
            if(id != kassaUpdateDTO.Id)
                return BadRequest();

            var kassa = await _context.Kassalar.FindAsync(id);
            if(kassa == null)
                return NotFound();

            kassa.Nomi = kassaUpdateDTO.Nomi;
            kassa.Turi = kassaUpdateDTO.Turi;
            kassa.Qoldiq = kassaUpdateDTO.Qoldiq;
            kassa.Aktiv = kassaUpdateDTO.Aktiv;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kassa = await _context.Kassalar.FindAsync(id);
            if(kassa == null)
                return NotFound();

            _context.Kassalar.Remove(kassa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
