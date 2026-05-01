using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Xomashyo;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XomashyoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public XomashyoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XomashyoGetDTO>>> GetAll()
        {
            return await _context.Xomashyolar
                .Select(x => new XomashyoGetDTO
                {
                    Id = x.Id,
                    Nomi = x.Nomi,
                    Miqdori = x.Miqdori,
                    OlchovBirligi = x.OlchovBirligi,
                    MinDaraja = x.MinDaraja,
                    Narxi = x.Narxi
                }).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<XomashyoGetDTO>> GetById(int Id)
        {
            var x = await _context.Xomashyolar.FindAsync(Id);
            if (x == null)
                return NotFound();
            return new XomashyoGetDTO
            {
                Id = x.Id,
                Nomi = x.Nomi,
                Miqdori = x.Miqdori,
                OlchovBirligi = x.OlchovBirligi,
                MinDaraja = x.MinDaraja,
                Narxi = x.Narxi
            };
        }
        [HttpPost]
        public async Task<ActionResult<XomashyoGetDTO>> Create(XomashyoCreateDTO xomashyoCreateDTO)
        {
            var xomashyo = new Xomashyo
            {
                Nomi = xomashyoCreateDTO.Nomi,
                Miqdori = xomashyoCreateDTO.Miqdori,
                OlchovBirligi = xomashyoCreateDTO.OlchovBirligi,
                MinDaraja = xomashyoCreateDTO.MinDaraja,
                Narxi = xomashyoCreateDTO.Narxi,
                Yaratilganvaqt = DateTime.Now,
            };
            _context.Xomashyolar.Add(xomashyo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = xomashyo.Id }, new XomashyoGetDTO
            {
                Id = xomashyo.Id,
                Nomi = xomashyo.Nomi,
                Miqdori = xomashyo.Miqdori,
                OlchovBirligi = xomashyo.OlchovBirligi,
                MinDaraja = xomashyo.MinDaraja,
                Narxi = xomashyo.Narxi
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, XomashyoUpdateDTO xomashyoUpdateDTO)
        {
            if (id != xomashyoUpdateDTO.Id)
                return BadRequest();

            var xomashyo = await _context.Xomashyolar.FindAsync(id);
            if (xomashyo == null)
                return NotFound();

            xomashyo.Nomi = xomashyoUpdateDTO.Nomi;
            xomashyo.Miqdori = xomashyoUpdateDTO.Miqdori;
            xomashyo.OlchovBirligi = xomashyoUpdateDTO.OlchovBirligi;
            xomashyo.MinDaraja = xomashyoUpdateDTO.MinDaraja;
            xomashyo.Narxi = xomashyoUpdateDTO.Narxi;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var xomashyo = await _context.Xomashyolar.FindAsync(id);
            if (xomashyo == null)
                return NotFound();
            _context.Xomashyolar.Remove(xomashyo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
