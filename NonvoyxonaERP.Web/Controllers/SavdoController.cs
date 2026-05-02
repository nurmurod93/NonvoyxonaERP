using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Savdo;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class SavdoController : Controller
    {
        private readonly ApiService _api;
        public SavdoController(ApiService api) => _api = api;
        
        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<SavdoGetDTO>>("Savdo");
            return View(list ?? new List<SavdoGetDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Savdo/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
