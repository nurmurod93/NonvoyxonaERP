using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Tochka;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class TochkaController : Controller
    {
        private readonly ApiService _api;
        public TochkaController(ApiService api) => _api = api;
        
        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<TochkaGetDTO>>("Tochka");
            return View(list ?? new List<TochkaGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TochkaGetDTO dto)
        {
            await _api.PostAsync<TochkaGetDTO>("Tochka", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Tochka/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
