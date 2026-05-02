using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Xodim;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class XodimlarController : Controller
    {
        private readonly ApiService _api;
        public XodimlarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<XodimGetDTO>>("Xodim");
            return View(list ?? new List<XodimGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(XodimCreateDTO dto)
        {
            await _api.PostAsync<XodimGetDTO>("Xodim", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Xodim/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
