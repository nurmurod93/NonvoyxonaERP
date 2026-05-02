using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Maosh;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class MaoshlarController : Controller
    {
        private readonly ApiService _api;
        public MaoshlarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<MaoshGetDTO>>("Maosh");
            return View(list ?? new List<MaoshGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(MaoshCreateDTO dto)
        {
            await _api.PostAsync<MaoshGetDTO>("Maosh", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Maosh/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}