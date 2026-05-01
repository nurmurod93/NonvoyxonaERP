using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Xodim;
using NonvoyxonaERP.Data;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XodimController : ControllerBase
    {
        private readonly AppDbContext _context;
        public XodimController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<XodimGetDTO>>> GetAll()
        {
            return await _context.Xodimlar
                .Select(x => new XodimGetDTO
                {
                    Id = x.Id,
                    FIO = x.FIO,
                    Telefon = x.Telefon,
                    Lavozimi = x.Lavozimi,
                    MaoshiTuri = x.MaoshiTuri,
                    AsosiyMaoshi = x.AsosiyMaoshi,
                    IshbayNarxi = x.IshbayNarxi,
                    IshgaKirgan = x.IshgaKirgan,
                    Aktiv = x.Aktive
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<XodimGetDTO>> GetById(int id)
        {
            var xodim = await _context.Xodimlar.FindAsync(id);
            if (xodim == null)
                return NotFound();
            return new XodimGetDTO
            {
                Id = xodim.Id,
                FIO = xodim.FIO,
                Telefon = xodim.Telefon,
                Lavozimi = xodim.Lavozimi,
                MaoshiTuri = xodim.MaoshiTuri,
                AsosiyMaoshi = xodim.AsosiyMaoshi,
                IshbayNarxi = xodim.IshbayNarxi,
                IshgaKirgan = xodim.IshgaKirgan,
                Aktiv = xodim.Aktive
            };
        }

        [HttpPost]
        public async Task<ActionResult<XodimGetDTO>> Create(XodimCreateDTO xodimCreateDTO)
        {
            var xodim = new Domain.Entities.Xodim
            {
                FIO = xodimCreateDTO.FIO,
                Telefon = xodimCreateDTO.Telefon,
                Lavozimi = xodimCreateDTO.Lavozimi,
                MaoshiTuri = xodimCreateDTO.MaoshiTuri,
                AsosiyMaoshi = xodimCreateDTO.AsosiyMaoshi,
                IshbayNarxi = xodimCreateDTO.IshbayNarxi,
                IshgaKirgan = xodimCreateDTO.IshgaKirgan
            };
            _context.Xodimlar.Add(xodim);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = xodim.Id }, new XodimGetDTO
            {
                Id = xodim.Id,
                FIO = xodim.FIO,
                Telefon = xodim.Telefon,
                Lavozimi = xodim.Lavozimi,
                MaoshiTuri = xodim.MaoshiTuri,
                AsosiyMaoshi = xodim.AsosiyMaoshi,
                IshbayNarxi = xodim.IshbayNarxi,
                IshgaKirgan = xodim.IshgaKirgan,
                Aktiv = xodim.Aktive
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, XodimUpdateDTO xodimUpdateDTO)
        {
            if(id != xodimUpdateDTO.Id)
                return BadRequest();
            var xodim = await _context.Xodimlar.FindAsync(id);
            if(xodim == null)
                return NotFound();
            xodim.FIO = xodimUpdateDTO.FIO;
            xodim.Telefon = xodimUpdateDTO.Telefon;
            xodim.Lavozimi = xodimUpdateDTO.Lavozimi;
            xodim.MaoshiTuri = xodimUpdateDTO.MaoshiTuri;
            xodim.AsosiyMaoshi = xodimUpdateDTO.AsosiyMaoshi;
            xodim.IshbayNarxi = xodimUpdateDTO.IshbayNarxi;
            xodim.Aktive = xodimUpdateDTO.Aktiv;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var xodim = await _context.Xodimlar.FindAsync(id);
            if (xodim == null)
                return NotFound();
            _context.Xodimlar.Remove(xodim);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
