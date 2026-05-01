using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Davomat;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DavomatController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DavomatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DavomatGetDTO>>> GetAll()
        {
            return await _context.Davomatlar
                .Include(d => d.Xodim)
                .Select(d => new DavomatGetDTO
                {
                    Id = d.Id,
                    XodimId = d.XodimId,
                    XodimFIO = d.Xodim.FIO,
                    Sana = d.Sana,
                    KeldiVaqt = d.KeldiVaqt,
                    KetdiVaqt = d.KetdiVaqt,
                    Smena = d.Smena,
                    Izoh = d.Izoh
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DavomatGetDTO>> GetById(int id)
        {
            var davomat = await _context.Davomatlar
                .Include(d => d.Xodim)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (davomat == null)
                return NotFound();

            return new DavomatGetDTO
            {
                Id = davomat.Id,
                XodimId = davomat.XodimId,
                XodimFIO = davomat.Xodim.FIO,
                Sana = davomat.Sana,
                KeldiVaqt = davomat.KeldiVaqt,
                KetdiVaqt = davomat.KetdiVaqt,
                Smena = davomat.Smena,
                Izoh = davomat.Izoh
            };
        }

        [HttpGet("xodim/{xodimId}")]
        public async Task<ActionResult<IEnumerable<DavomatGetDTO>>> GetByXodim(int xodimId)
        {
            return await _context.Davomatlar
                .Include(d => d.Xodim)
                .Where(d => d.XodimId == xodimId)
                .Select(d => new DavomatGetDTO
                {
                    Id = d.Id,
                    XodimId = d.XodimId,
                    XodimFIO = d.Xodim.FIO,
                    Sana = d.Sana,
                    KeldiVaqt = d.KeldiVaqt,
                    KetdiVaqt = d.KetdiVaqt,
                    Smena = d.Smena,
                    Izoh = d.Izoh
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DavomatGetDTO>> Create(DavomatCreateDTO davomatCreateDTO)
        {
            var xodim = await _context.Xodimlar.FindAsync(davomatCreateDTO.XodimId);
            if (xodim == null)
                return BadRequest($"XodimId={davomatCreateDTO.XodimId} mavjud emas!.");

            var davomat = new Davomat
            {
                XodimId = davomatCreateDTO.XodimId,
                Sana = davomatCreateDTO.Sana,
                KeldiVaqt = davomatCreateDTO.KeldiVaqt,
                KetdiVaqt = davomatCreateDTO.KetdiVaqt,
                Smena = davomatCreateDTO.Smena,
                Izoh = davomatCreateDTO.Izoh,
                Yaratilganvaqt = DateTime.UtcNow,
            };

            _context.Davomatlar.Add(davomat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = davomat.Id },
                new DavomatGetDTO
                {
                    Id = davomat.Id,
                    XodimId = davomat.XodimId,
                    XodimFIO = xodim.FIO,
                    Sana = davomat.Sana,
                    KeldiVaqt = davomat.KeldiVaqt,
                    KetdiVaqt = davomat.KetdiVaqt,
                    Smena = davomat.Smena,
                    Izoh = davomat.Izoh
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DavomatUpdateDTO davomatUpdateDTO)
        {
            if (id != davomatUpdateDTO.Id)
                return BadRequest("ID mos emas!");

            var davomat = await _context.Davomatlar.FindAsync(id);
            if (davomat == null)
                return NotFound();

            davomat.KeldiVaqt = davomatUpdateDTO.KeldiVaqt;
            davomat.KetdiVaqt = davomatUpdateDTO.KetdiVaqt;
            davomat.Smena = davomatUpdateDTO.Smena;
            davomat.Izoh = davomatUpdateDTO.Izoh;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var davomat = await _context.Davomatlar.FindAsync(id);
            if (davomat == null)
                return NotFound();
            _context.Davomatlar.Remove(davomat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
