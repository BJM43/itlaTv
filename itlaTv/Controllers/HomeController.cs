using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using itlaTv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace itlaTv.Controllers
{
    public class HomeController : Controller
    {
        private readonly TvSerieService _tvSerieService;

        public HomeController(ApplicationContext dbContext)
        {
            _tvSerieService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tvSerieService.GetAllViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}