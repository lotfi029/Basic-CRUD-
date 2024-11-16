using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;

        public HomeController(
            ILogger<HomeController> logger,
            IGameService gameService
            )
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAll();
            return View(games);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
