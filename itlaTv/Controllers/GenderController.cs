using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace itlaTv.Controllers
{
    public class GenderController : Controller
    {
        private readonly GenderService _genderService;

        public GenderController(ApplicationContext dbContext)
        {
            _genderService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _genderService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveGender", new SaveGenderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGenderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }

            await _genderService.Add(vm);
            return RedirectToRoute(new { Controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGender", await _genderService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGenderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }

            await _genderService.Update(vm);
            return RedirectToRoute(new { Controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _genderService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _genderService.Delete(id);
            return RedirectToRoute(new { Controller = "Gender", action = "Index" });
        }
    }
}
