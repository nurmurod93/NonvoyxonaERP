using Microsoft.AspNetCore.Mvc;
using NonvoyxonaERP.Application.DTOs.Maxsulot;
using NonvoyxonaERP.Web.Services;

namespace NonvoyxonaERP.Web.Controllers
{
    public class MaxsulotlarController : Controller
    {
        private readonly ApiService _api;
        public MaxsulotlarController(ApiService api)
        {
            _api = api;
        }

        //Get
        public async Task<IActionResult> Index()
        {
            var list = await _api.GetAsync<List<MaxsulotGetDTO>>("Maxsulotlar");
            return View(list ?? new List<MaxsulotGetDTO>());
        }

        //Post
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaxsulotCreateDTO maxsulotCreateDTO)
        {
            if(!ModelState.IsValid)
                return View(maxsulotCreateDTO);

            await _api.PostAsync<MaxsulotGetDTO>("Maxsulotlar", maxsulotCreateDTO);
            return RedirectToAction(nameof(Index));
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var maxsulot = await _api.GetAsync<MaxsulotGetDTO>($"Maxsulotlar/{id}");
            if(maxsulot == null)
                return NotFound();
            return View(maxsulot);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _api.DeleteAsync($"Maxsulotlar/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
