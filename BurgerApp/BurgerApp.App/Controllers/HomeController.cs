using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.App.Controllers
{
    public class HomeController : Controller
    {
        private IBurgerService _burgerService;

        public HomeController(ILogger<HomeController> logger, IBurgerService _burgerService)
        {
            this._burgerService = _burgerService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.BurgerForPromotion = _burgerService.GetBurgerForPromotion();
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}