using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Maosh;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaoshController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MaoshController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaoshGetDTO>>> GetAll()
        {
            return await _context.Maoshlar
                .Include(m => m.Xodim)
                .Select(m => new MaoshGetDTO
                {
                    Id = m.Id,
                    XodimId = m.XodimId,
                    XodimFIO = m.Xodim.FIO,
                    Yil = m.Yil,
                    Oy = m.Oy,
                    HisoblanganMaosh = m.HisoblanganMaosh,
                    Avans = m.Avans,
                    Shtraf = m.Shtraf,
                    Mukofot = m.Mukofot,
                    Tolangan = m.Tolangan,
                    TolashSana = m.TolashSana
                })
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MaoshGetDTO>> GetById(int id)
        {
            var maosh = await _context.Maoshlar
                .Include(m => m.Xodim)
                .FirstOrDefaultAsync(m => m.Id == id);

            if(maosh == null)
                return NotFound();

            return new MaoshGetDTO
            {
                Id = maosh.Id,
                XodimId = maosh.XodimId,
                XodimFIO = maosh.Xodim.FIO,
                Yil = maosh.Yil,
                Oy = maosh.Oy,
                HisoblanganMaosh = maosh.HisoblanganMaosh,
                Avans = maosh.Avans,
                Shtraf = maosh.Shtraf,
                Mukofot = maosh.Mukofot,
                Tolangan = maosh.Tolangan,
                TolashSana = maosh.TolashSana
            };
        }

        [HttpGet("xodim/{xodimId}")]
        public async Task<ActionResult<IEnumerable<MaoshGetDTO>>> GetByXodim(int xodimId)
        {
            return await _context.Maoshlar
                .Include(m => m.Xodim)
                .Where(m => m.XodimId == xodimId)
                .Select(m => new MaoshGetDTO
                {
                    Id = m.Id,
                    XodimId = m.XodimId,
                    XodimFIO = m.Xodim.FIO,
                    Yil = m.Yil,
                    Oy = m.Oy,
                    HisoblanganMaosh = m.HisoblanganMaosh,
                    Avans = m.Avans,
                    Shtraf = m.Shtraf,
                    Mukofot = m.Mukofot,
                    Tolangan = m.Tolangan,
                    TolashSana = m.TolashSana
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MaoshGetDTO>> Create(MaoshCreateDTO maoshCreateDTO)
        {
            var xodim = await _context.Xodimlar.FindAsync(maoshCreateDTO.XodimId);
            if(xodim == null)
                return BadRequest($"XodimId={maoshCreateDTO.XodimId} mavjud emas!");

            var mavjud = await _context.Maoshlar
                .AnyAsync(m => m.XodimId == maoshCreateDTO.XodimId
                && m.Yil == maoshCreateDTO.Yil
                && m.Oy == maoshCreateDTO.Oy);

            if(mavjud)
                return BadRequest($"Bu xodim uchun {maoshCreateDTO.Yil}/{maoshCreateDTO.Oy} oyi maoshi allaqachon mavjud!");

            var maosh = new Maosh
            {
                XodimId = maoshCreateDTO.XodimId,
                Yil = maoshCreateDTO.Yil,
                Oy = maoshCreateDTO.Oy,
                HisoblanganMaosh = maoshCreateDTO.HisoblanganMaosh,
                Avans = maoshCreateDTO.Avans,
                Shtraf = maoshCreateDTO.Shtraf,
                Mukofot = maoshCreateDTO.Mukofot,
                Tolangan = 0,
                Yaratilganvaqt = DateTime.Now,
            };

            _context.Maoshlar.Add(maosh);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = maosh.Id },
                new MaoshGetDTO
                {
                    Id = maosh.Id,
                    XodimId = maosh.XodimId,
                    XodimFIO = xodim.FIO,
                    Yil = maosh.Yil,
                    Oy = maosh.Oy,
                    HisoblanganMaosh = maosh.HisoblanganMaosh,
                    Avans = maosh.Avans,
                    Shtraf = maosh.Shtraf,
                    Mukofot = maosh.Mukofot,
                    Tolangan = maosh.Tolangan,
                });
        }

        [HttpPut("{id}/tolash")]
        public async Task<IActionResult> Update(int id, MaoshUpdateDTO maoshUpdateDTO)
        {
            if(id != maoshUpdateDTO.Id)
                return BadRequest();

            var maosh = await _context.Maoshlar.FindAsync(id);
            if(maosh == null)
                return NotFound();

            maosh.Avans = maoshUpdateDTO.Avans;
            maosh.Shtraf = maoshUpdateDTO.Shtraf;
            maosh.Mukofot = maoshUpdateDTO.Mukofot;
            maosh.Tolangan = maoshUpdateDTO.Tolangan;
            maosh.TolashSana = maoshUpdateDTO.TolashSana ?? DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var maosh = await _context.Maoshlar.FindAsync(id);
            if(maosh == null)
                return NotFound();

            _context.Maoshlar.Remove(maosh);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
