using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Savdo;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavdoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SavdoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavdoGetDTO>>> GetAll()
        {
            return await _context.Savdolar
                .Include(s => s.Tochka)
                .Include(s => s.Xodim)
                .Select(s => new SavdoGetDTO
                {
                    Id = s.Id,
                    TochkaId = s.TochkaId,
                    TochkaNomi = s.Tochka !=null ? s.Tochka.Nomi : "Markaziy",
                    XodimId = s.XodimId,
                    XodimFIO = s.Xodim.FIO,
                    JamiSumma = s.JamiSumma,
                    TolovTuri = s.TolovTuri,
                    Holat = s.Holat,
                    YaratilganVaqt = s.Yaratilganvaqt
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SavdoGetDTO>> GetById(int id)
        {
            var s = await _context.Savdolar
                .Include(s => s.Tochka)
                .Include(s => s.Xodim)
                .FirstOrDefaultAsync(s => s.Id == id);
            if(s == null)
                return NotFound();
            return new SavdoGetDTO
            {
                Id = id,
                TochkaId= s.TochkaId,
                TochkaNomi = s.Tochka != null ? s.Tochka.Nomi : "Markaziy",
                XodimId = s.XodimId,
                XodimFIO = s.Xodim.FIO,
                JamiSumma = s.JamiSumma,
                TolovTuri = s.TolovTuri,
                Holat = s.Holat,
                YaratilganVaqt = s.Yaratilganvaqt
            };
        }

        [HttpPost]
        public async Task<ActionResult<SavdoGetDTO>> Create(SavdoCreateDTO savdoCreateDTO)
        {
            decimal jamiSumma = savdoCreateDTO.Qatorlar.Sum(q => q.Miqdor * q.Narx);

            var savdo = new Savdo
            {
                TochkaId = savdoCreateDTO.TochkaId,
                XodimId = savdoCreateDTO.XodimId,
                JamiSumma = jamiSumma,
                TolovTuri = savdoCreateDTO.TolovTuri,
                Holat = "Yakunlangan",
                Yaratilganvaqt = DateTime.Now,
            };

            foreach(var q in savdoCreateDTO.Qatorlar)
            {
                savdo.Qatorlar.Add(new SavdoQator
                {
                    MaxsulotId = q.MaxsulotId,
                    Miqdor = q.Miqdor,
                    Narx = q.Narx,
                    Yaratilganvaqt= DateTime.Now,
                });
            }
            _context.Savdolar.Add(savdo);
            await _context.SaveChangesAsync();

            var xodim = await _context.Xodimlar.FindAsync(savdo.XodimId);

            return CreatedAtAction(nameof(GetById), new {id = savdo.Id},
                new SavdoGetDTO
                {
                    Id = savdo.Id,
                    TochkaId = savdo.TochkaId,
                    TochkaNomi = "Markaziy",
                    XodimId = savdo.XodimId,
                    XodimFIO = xodim?.FIO ?? string.Empty,
                    JamiSumma = savdo.JamiSumma,
                    TolovTuri = savdo.TolovTuri,
                    Holat = savdo.Holat,
                    YaratilganVaqt = savdo.Yaratilganvaqt,
                });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, SavdoUpdateDTO savdoUpdateDTO)
        {
            if (Id != savdoUpdateDTO.Id)
                return BadRequest();

            var savdo = await _context.Savdolar.FindAsync(Id);
            if (savdo == null)
                return NotFound();
            savdo.TolovTuri = savdoUpdateDTO.TolovTuri;
            savdo.Holat = savdoUpdateDTO.Holat;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var savdo = await _context.Savdolar.FindAsync(id);
            if(savdo == null)
                return NotFound();

            _context.Savdolar.Remove(savdo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
