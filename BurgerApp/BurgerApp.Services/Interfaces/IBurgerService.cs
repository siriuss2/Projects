using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        Task<List<BurgerListViewModel>> GetBurgersForCards();
        Task<BurgerDetailsViewModel> GetBurgerDetails(int id);
        Task<int> DeleteBurgerById(int id);
        Task CreateBurger(BurgerViewModel burgerViewModel);
        Task<BurgerViewModel> GetBurgerForEditing(int id);
        Task EditBurger(BurgerViewModel burgerViewModel);
        string GetBurgerForPromotion();
        Task<List<BurgersForDropdownViewModel>> GetBurgersForDropdown();
    }
}
