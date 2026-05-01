using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.IshAkt;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IshAktController : ControllerBase
    {
        private readonly AppDbContext _context;
        public IshAktController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IshAktGetDTO>>> GettAll()
        {
            return await _context.IshAktlar
                .Include(i => i.Xodim)
                .Include(i => i.Qatorlar)
                .ThenInclude(q => q.Maxsulot)
                .Select(i => new IshAktGetDTO
                {
                    Id = i.Id,
                    Sana = i.Sana,
                    XodimId = i.XodimId,
                    XodimFIO = i.Xodim.FIO,
                    Smena = i.Smena,
                    Holat = i.Holat,
                    YaratilganVaqt = i.Yaratilganvaqt,
                    Qatorlar = i.Qatorlar.Select(q => new IshAktQatorGetDTO
                    {
                        Id = q.Id,
                        MaxsulotId = q.MaxsulotId,
                        MaxsulotNomi = q.Maxsulot.Nomi,
                        RejalashMiqdor = q.RejalashMiqdor,
                        HaqiqiyMiqdor = q.HaqiqiyMiqdor,
                        BrakMiqdor = q.BrakMiqdor,
                    }).ToList()
                }).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IshAktGetDTO>> GetById(int id)
        {
            var ishakt = await _context.IshAktlar
                .Include(i => i.Xodim)
                .Include(i => i.Qatorlar)
                .ThenInclude(q => q.Maxsulot)
                .FirstOrDefaultAsync(i => i.Id == id);


                if (ishakt == null)
                return NotFound();

            return new IshAktGetDTO
            {
                Id = ishakt.Id,
                Sana = ishakt.Sana,
                XodimId = ishakt.XodimId,
                XodimFIO = ishakt.Xodim.FIO,
                Smena = ishakt.Smena,
                Holat = ishakt.Holat,
                YaratilganVaqt = ishakt.Yaratilganvaqt,
                Qatorlar = ishakt.Qatorlar.Select(q => new IshAktQatorGetDTO
                {
                    Id = q.Id,
                    MaxsulotId = q.MaxsulotId,
                    MaxsulotNomi = q.Maxsulot.Nomi,
                    RejalashMiqdor = q.RejalashMiqdor,
                    HaqiqiyMiqdor = q.HaqiqiyMiqdor,
                    BrakMiqdor = q.BrakMiqdor,
                }).ToList()
            };
        }

        [HttpPost]
        public async Task<ActionResult<IshAktGetDTO>> Create(IshAktCreateDTO ishAktCreateDTO)
        {
            var xodim = await _context.Xodimlar.FindAsync(ishAktCreateDTO.XodimId);
            if(xodim == null)
                return BadRequest($"XodimId=(ishAktCreateDTO.XodimId) Mavjud emas!");

            var akt = new IshAkt
            {
                Sana = ishAktCreateDTO.Sana,
                XodimId = ishAktCreateDTO.XodimId,
                Smena = ishAktCreateDTO.Smena,
                Holat = "Ochiq",
                Yaratilganvaqt = DateTime.Now,
            };

            foreach(var q in ishAktCreateDTO.Qatorlar)
            {
                var maxsulot = await _context.Maxsulotlar.FindAsync(q.MaxsulotId);
                if(maxsulot == null)
                    return BadRequest($"MaxsulotId={q.MaxsulotId} Mavjud emas!");

                akt.Qatorlar.Add(new IshAktQator
                {
                    MaxsulotId = q.MaxsulotId,
                    RejalashMiqdor = q.RejalashMiqdor,
                    HaqiqiyMiqdor = q.HaqiqiyMiqdor,
                    BrakMiqdor = q.BrakMiqdor,
                    Yaratilganvaqt = DateTime.Now,
                });
            }

            _context.IshAktlar.Add(akt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = akt.Id }, 
                new IshAktGetDTO
                {
                    Id = akt.Id,
                    Sana = akt.Sana,
                    XodimId = akt.XodimId,
                    XodimFIO = xodim.FIO,
                    Smena = akt.Smena,
                    Holat = akt.Holat,
                    YaratilganVaqt = akt.Yaratilganvaqt,
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IshAktUpdateDTO ishAktUpdateDTO)
        {
            if(id != ishAktUpdateDTO.Id)
                return BadRequest("ID topilmadi yoki mos emas!");

            var akt = await _context.IshAktlar.FindAsync(id);
            if (akt == null)
                return NotFound();

            akt.Smena = ishAktUpdateDTO.Smena;
            akt.Holat = ishAktUpdateDTO.Holat;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             var akt = await _context.IshAktlar.FindAsync(id);
            if (akt == null)
                return NotFound();
            _context.IshAktlar.Remove(akt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
