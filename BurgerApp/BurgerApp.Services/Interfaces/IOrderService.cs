using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListViewModel>> GetAllOrders();
        Task<int> DeleteOrderById(int id);
        Task CreateOrder(OrderViewModel orderViewModel);
        Task<OrderViewModel> GetOrderForEditing(int id);
        Task EditOrder(OrderViewModel orderViewModel);
    }
}
