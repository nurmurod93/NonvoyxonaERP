using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonvoyxonaERP.Application.DTOs.Transfer;
using NonvoyxonaERP.Data;
using NonvoyxonaERP.Domain.Entities;

namespace NonvoyxonaERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TransferController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrnsferGetDTO>>> GetAll()
        {
            return await _context.Transferlar
                .Include(t => t.Tochka)
                .Include(t => t.Xodim)
                .Include(t => t.Qatorlar)
                .ThenInclude(q => q.Maxsulot)
                .Select(t => new TrnsferGetDTO
                {
                    Id = t.Id,
                    TochkaId = t.TochkaId,
                    TochkaNomi = t.Tochka.Nomi,
                    XodimId = t.XodimId,
                    XodimFIO = t.Xodim.FIO,
                    Holat = t.Holat,
                    Izoh = t.Izoh,
                    YaratilganVaqt = t.Yaratilganvaqt,
                    Qatorlar = t.Qatorlar.Select(q => new TransferQatorGetDTO
                    {
                        Id = q.Id,
                        MaxsulotId = q.MaxsulotId,
                        MaxsulotNomi = q.Maxsulot.Nomi,
                        YuborilganMiq = q.YuborilganMiq,
                        QabulMiqdor = q.QabulMiqdor
                    }).ToList()
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrnsferGetDTO>> GetById(int id)
        {
            var transfer = await _context.Transferlar
                .Include(t => t.Tochka)
                .Include(t => t.Xodim)
                .Include(t => t.Qatorlar)
                .ThenInclude(q => q.Maxsulot)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transfer == null)
                return NotFound();

            return new TrnsferGetDTO
            {
                Id = transfer.Id,
                TochkaId = transfer.TochkaId,
                TochkaNomi = transfer.Tochka.Nomi,
                XodimId = transfer.XodimId,
                XodimFIO = transfer.Xodim.FIO,
                Holat = transfer.Holat,
                Izoh = transfer.Izoh,
                YaratilganVaqt = transfer.Yaratilganvaqt,
                Qatorlar = transfer.Qatorlar
                .Select(q => new TransferQatorGetDTO
                {
                    Id = q.Id,
                    MaxsulotId = q.MaxsulotId,
                    MaxsulotNomi = q.Maxsulot.Nomi,
                    YuborilganMiq = q.YuborilganMiq,
                    QabulMiqdor = q.QabulMiqdor
                }).ToList()
            };
        }

        [HttpPost]
        public async Task<ActionResult<TrnsferGetDTO>> Create(TransferCreateDTO transferCreateDTO)
        {
            var tochka = await _context.Tochkalar.FindAsync(transferCreateDTO.TochkaId);
            if (tochka == null)
                return BadRequest($"TochkaID = {transferCreateDTO.TochkaId} mavjud emas.");

            var xodim = await _context.Xodimlar.FindAsync(transferCreateDTO.XodimId);
            if (xodim == null)
                return BadRequest($"XodimID = {transferCreateDTO.XodimId} mavjud emas.");

            var transfer = new Transfer
            {
                TochkaId = transferCreateDTO.TochkaId,
                XodimId = transferCreateDTO.XodimId,
                Holat = "Yo'lda",
                Izoh = transferCreateDTO.Izoh,
                Yaratilganvaqt = DateTime.UtcNow,
            };
            foreach (var qator in transferCreateDTO.Qatorlar)
            {
                var maxsulot = await _context.Maxsulotlar.FindAsync(qator.MaxsulotId);
                if (maxsulot == null)
                    return BadRequest($"MaxsulotID = {qator.MaxsulotId} mavjud emas.");

                transfer.Qatorlar.Add(new TransferQator
                {
                    MaxsulotId = qator.MaxsulotId,
                    YuborilganMiq = qator.YuborilganMiq,
                    QabulMiqdor = 0,
                    Yaratilganvaqt = DateTime.UtcNow,
                });
            }
            _context.Transferlar.Add(transfer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = transfer.Id },
                new TrnsferGetDTO
                {
                    Id = transfer.Id,
                    TochkaId = transfer.TochkaId,
                    TochkaNomi = tochka.Nomi,
                    XodimId = transfer.XodimId,
                    XodimFIO = xodim.FIO,
                    Holat = transfer.Holat,
                    Izoh = transfer.Izoh,
                    YaratilganVaqt = transfer.Yaratilganvaqt,

                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TransferUpdateDTO transferUpdateDTO)
        {
            if (id != transferUpdateDTO.Id)
                return BadRequest("ID mos emas.");

            var transfer = await _context.Transferlar
                .Include(t => t.Qatorlar)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transfer == null)
                return NotFound();

            transfer.Holat = transferUpdateDTO.Holat;
            transfer.Izoh = transferUpdateDTO.Izoh;

            if (transferUpdateDTO.Holat == "Qabul qilindi")
            {
                foreach (var qator in transfer.Qatorlar)
                {
                    qator.QabulMiqdor = qator.YuborilganMiq;
                }
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transfer = await _context.Transferlar.FindAsync(id);
            if (transfer == null)
                return NotFound();
            _context.Transferlar.Remove(transfer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
