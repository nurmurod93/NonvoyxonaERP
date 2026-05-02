using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Xomashyo;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class XomashyoController : Controller
    {
        private readonly ApiService _api;
        public XomashyoController(ApiService api) => _api = api;
        
        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<XomashyoGetDTO>>("Xomashyo");
            return View(list ?? new List<XomashyoGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(XomashyoCreateDTO dto)
        {
            await _api.PostAsync<XomashyoGetDTO>("Xomashyo",  dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Xomashyo/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
