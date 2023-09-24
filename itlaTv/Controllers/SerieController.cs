using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace itlaTv.Controllers
{
    public class SerieController : Controller
    {
        private readonly TvSerieService _tvSerieService;

        public SerieController(ApplicationContext dbContext)
        {
            _tvSerieService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tvSerieService.GetAllViewModel());
        }

        public IActionResult Create() 
        {
            return View("SaveTvSerie", new SaveTvSerieViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTvSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTvSerie", vm);
            }

            await _tvSerieService.Add(vm);
            return RedirectToRoute(new { Controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTvSerie", await _tvSerieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTvSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTvSerie", vm);
            }

            await _tvSerieService.Update(vm);
            return RedirectToRoute(new { Controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _tvSerieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tvSerieService.Delete(id);
            return RedirectToRoute(new { Controller = "Serie", action = "Index" });
        }
    }
}
