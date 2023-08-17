using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.App.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private ILocationService _locationService;
        private IBurgerService _burgerService;

        public OrderController(IOrderService _orderService, ILocationService _locationService, IBurgerService _burgerService)
        {
            this._orderService = _orderService;
            this._locationService = _locationService;
            this._burgerService = _burgerService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetAllOrders());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _orderService.DeleteOrderById(id));
        }

        public async Task<IActionResult> Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Locations = await _locationService.GetLocationsForDropdown();
            ViewBag.Burgers = await _burgerService.GetBurgersForDropdown();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {
            await _orderService.CreateOrder(orderViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            OrderViewModel orderViewModel = await _orderService.GetOrderForEditing(id);
            ViewBag.Locations = await _locationService.GetLocationsForDropdown();
            ViewBag.Burgers = await _burgerService.GetBurgersForDropdown();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderViewModel orderViewModel)
        {
            await _orderService.EditOrder(orderViewModel);

            return RedirectToAction("Index");
        }
    }
}
