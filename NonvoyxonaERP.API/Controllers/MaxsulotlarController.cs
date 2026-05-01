using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Maxsulot;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaxsulotlarController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MaxsulotlarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaxsulotGetDTO>>> GetAll()
        {
            return await _context.Maxsulotlar
                .Select(m => new MaxsulotGetDTO
                {
                    Id = m.Id,
                    Nomi = m.Nomi,
                    Kategoryasi = m.Kategoryasi,
                    Narxi = m.Narxi,
                    Olchovbirligi = m.OlchovBirligi,
                    Aktiv = m.Aktiv
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaxsulotGetDTO>> GetById(int id)
        {
            var maxsulot = await _context.Maxsulotlar.FindAsync(id);
            if (maxsulot == null)
                return NotFound();
            return new MaxsulotGetDTO
            {
                Id = maxsulot.Id,
                Nomi = maxsulot.Nomi,
                Kategoryasi = maxsulot.Kategoryasi,
                Narxi = maxsulot.Narxi,
                Olchovbirligi = maxsulot.OlchovBirligi,
                Aktiv = maxsulot.Aktiv
            };
        }

        [HttpPost]
        public async Task<ActionResult<MaxsulotGetDTO>> Create(MaxsulotCreateDTO maxsulotCreateDTO)
        {
            var maxsulot = new Maxsulot
            {
                Nomi = maxsulotCreateDTO.Nomi,
                Kategoryasi = maxsulotCreateDTO.Kategoryasi,
                Narxi = maxsulotCreateDTO.Narxi,
                OlchovBirligi = maxsulotCreateDTO.OlchovBirligi,
                Aktiv = true,
                Yaratilganvaqt = DateTime.Now
            };
           
            _context.Maxsulotlar.Add(maxsulot);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = maxsulot.Id },
                new MaxsulotGetDTO
                {
                    Id = maxsulot.Id,
                    Nomi = maxsulot.Nomi,
                    Kategoryasi = maxsulot.Kategoryasi,
                    Narxi = maxsulot.Narxi,
                    Olchovbirligi = maxsulot.OlchovBirligi,
                    Aktiv = maxsulot.Aktiv
                });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaxsulotUpdateDTO maxsulotUpdateDTO)
        {
            if(id != maxsulotUpdateDTO.Id)
                return BadRequest();
            var maxsulot = await _context.Maxsulotlar.FindAsync(id);
            if(maxsulot == null)
                return NotFound();
            maxsulot.Nomi = maxsulotUpdateDTO.Nomi;
            maxsulot.Kategoryasi = maxsulotUpdateDTO.Kategoryasi;
            maxsulot.Narxi = maxsulotUpdateDTO.Narxi;
            maxsulot.OlchovBirligi = maxsulotUpdateDTO.OlchovBirligi;
            maxsulot.Aktiv = maxsulotUpdateDTO.Aktiv;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var maxsulotlar = await _context.Maxsulotlar.FindAsync(id);
            if(maxsulotlar == null)
                return NotFound();

            _context.Maxsulotlar.Remove(maxsulotlar);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
