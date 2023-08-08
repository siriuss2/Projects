using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Mappers.BurgerMappers;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IBurgerRepository _burgerRepository;

        public BurgerService(IBurgerRepository _burgerRepository)
        {
            this._burgerRepository = _burgerRepository;
        }

        public Task CreateBurger(BurgerViewModel burgerViewModel)
        {
            return _burgerRepository.Insert(burgerViewModel.ToBurger());
        }

        public async Task<int> DeleteBurgerById(int id)
        {
            return await _burgerRepository.DeleteById(id);
        }

        public async Task EditBurger(BurgerViewModel burgerViewModel)
        {
            Burger burgerDb = await _burgerRepository.GetById(burgerViewModel.Id) ?? throw new Exception("Burger not found");

            burgerDb.Name = burgerViewModel.Name;
            burgerDb.IsVegetarian = burgerViewModel.IsVegetarian;
            burgerDb.IsVegan = burgerViewModel.IsVegan;
            burgerDb.HasFries = burgerViewModel.HasFries;
            burgerDb.ImageUrl = burgerViewModel.ImageUrl;
            burgerDb.Price = burgerViewModel.Price;
            burgerDb.IsOnPromotion = burgerViewModel.IsOnPromotion;

            await _burgerRepository.Update(burgerDb);
        }

        public async Task<BurgerDetailsViewModel> GetBurgerDetails(int id)
        {
            Burger burgerDb = await _burgerRepository.GetById(id);
            return burgerDb.ToBurgerDetailsViewModel();
        }

        public async Task<BurgerViewModel> GetBurgerForEditing(int id)
        {
            Burger burger = await _burgerRepository.GetById(id) ?? throw new Exception("Burger not found!");

            BurgerViewModel burgerViewModel = burger.ToBurgerViewModel();
            return burgerViewModel;
        }

        public string GetBurgerForPromotion()
        {
            return _burgerRepository.GetBurgerForPromotion().Name;
        }

        public async Task<List<BurgerListViewModel>> GetBurgersForCards()
        {
            List<Burger> burgerDb = await _burgerRepository.GetAll();
            return burgerDb.Select(x => x.ToBurgerListViewModel()).ToList();
        }

        public async Task<List<BurgersForDropdownViewModel>> GetBurgersForDropdown()
        {
            List<Burger> burgerDb = await _burgerRepository.GetAll();
            return burgerDb.Select(x => x.ToBurgersForDropDown()).ToList();
        }
    }
}
