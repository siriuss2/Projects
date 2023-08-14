using TaxiManager.DomainModels.Models;

namespace TaxiManager.Services.Interfaces
{
    public interface ICarService : IServiceBase<Car>
    {
        bool IsCarAvailable(Car car);
    }
}
