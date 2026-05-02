using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Davomat;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class DavomatlarController : Controller
    {
        private readonly ApiService _api;
        public DavomatlarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<DavomatGetDTO>>("Davomat");
            return View(list ?? new List<DavomatGetDTO>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(DavomatCreateDTO dto)
        {
            await _api.PostAsync<DavomatGetDTO>("Davomat", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Davomat/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}