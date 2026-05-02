using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Transfer;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class TransferlarController : Controller
    {
        private readonly ApiService _api;
        public TransferlarController(ApiService api) => _api = api;

        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<TrnsferGetDTO>>("Transfer");
            return View(list ?? new List<TrnsferGetDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _api.DeleteAsync($"Transfer/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}