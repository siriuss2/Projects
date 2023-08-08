using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Mappers.BurgerMappers
{
    public static class BurgerListViewModelMapper
    {
        public static BurgerListViewModel ToBurgerListViewModel(this Burger burger)
        {
            return new BurgerListViewModel()
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                ImageUrl = burger.ImageUrl,
                HasFries = burger.HasFries,
                IsOnPromotion = burger.IsOnPromotion
            };
        }

        public static BurgerDetailsViewModel ToBurgerDetailsViewModel(this Burger burger)
        {
            return new BurgerDetailsViewModel()
            {
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                Name = burger.Name,
                Price = burger.Price,
                ImageUrl = burger.ImageUrl,
                IsOnPromotion = burger.IsOnPromotion
            };
        }

        public static Burger ToBurger(this BurgerViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.Name,
                Price = burgerViewModel.Price,
                ImageUrl = burgerViewModel.ImageUrl,
                HasFries = burgerViewModel.HasFries,
                IsVegan = burgerViewModel.IsVegan,
                IsVegetarian = burgerViewModel.IsVegetarian,
                IsOnPromotion = burgerViewModel.IsOnPromotion
            };
        }

        public static BurgerViewModel ToBurgerViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                ImageUrl = burger.ImageUrl,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                IsOnPromotion = burger.IsOnPromotion
            };
        }

        public static BurgersForDropdownViewModel ToBurgersForDropDown(this Burger burger)
        {
            return new BurgersForDropdownViewModel
            {
                Id = burger.Id,
                Name = burger.Name
            };
        }
    }
}
