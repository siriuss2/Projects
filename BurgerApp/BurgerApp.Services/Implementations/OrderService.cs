using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Mappers.OrderMappers;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> _orderRepository)
        {
            this._orderRepository = _orderRepository;
        }

        public Task CreateOrder(OrderViewModel orderViewModel)
        {
            return _orderRepository.Insert(orderViewModel.ToOrder());
        }

        public async Task<int> DeleteOrderById(int id)
        {
            return await _orderRepository.DeleteById(id);
        }

        public async Task EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = await _orderRepository.GetById(orderViewModel.Id) ?? throw new Exception("Order not found!");

            orderDb.FullName = orderViewModel.FullName;
            orderDb.Address = orderViewModel.Address;
            orderDb.Id = orderViewModel.Id;
            orderDb.IsDelivered = orderViewModel.IsDelivered;
            orderDb.LocationId = orderViewModel.LocationId;

            await _orderRepository.Update(orderDb);
        }

        public async Task<List<OrderListViewModel>> GetAllOrders()
        {
            List<Order> orderDb = await _orderRepository.GetAll();
            return orderDb.Select(x => x.ToOrderListViewModel()).ToList();
        }

        public async Task<OrderViewModel> GetOrderForEditing(int id)
        {
            Order order = await _orderRepository.GetById(id) ?? throw new Exception("Order not found!");

            OrderViewModel orderViewModel = order.ToOrderViewModel();
            return orderViewModel;

        }
    }
}
