using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Kassa;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class KassalarController : Controller
    {
        private readonly ApiService _api;
        public KassalarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<KassaGetDTO>>("Kassa");
            return View(list ?? new List<KassaGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(KassaCreateDTO dto)
        {
            await _api.PostAsync<KassaGetDTO>("Kassa", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Kassa/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}