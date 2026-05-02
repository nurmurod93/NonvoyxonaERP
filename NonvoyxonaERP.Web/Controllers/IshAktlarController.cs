using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.IshAkt;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class IshAktlarController : Controller
    {
        private readonly ApiService _api;
        public IshAktlarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<IshAktGetDTO>>("IshAkt");
            return View(list ?? new List<IshAktGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(IshAktCreateDTO dto)
        {
            await _api.PostAsync<IshAktGetDTO>("IshAkt", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"IshAkt/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}