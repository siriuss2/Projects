using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.LocationViewModels;

namespace BurgerApp.Mappers.LocationMappers
{
    public static class LocationViewModelMapper
    {
        public static LocationListViewModel ToLocationListViewModel(this Location location)
        {
            return new LocationListViewModel
            {
                Id = location.Id,
                Address = location.Address,
                ClosesAt = location.ClosesAt,
                Name = location.Name,
                OpensAt = location.OpensAt
            };
        }

        public static Location ToLocation(this LocationViewModel locationViewModel)
        {
            return new Location
            {
                Id = locationViewModel.Id,
                Address = locationViewModel.Address,
                ClosesAt = locationViewModel.ClosesAt,
                Name = locationViewModel.Name,
                OpensAt = locationViewModel.OpensAt
            };
        }

        public static LocationsForDropdownViewModel ToLocationsForDropdown(this Location location)
        {
            return new LocationsForDropdownViewModel
            {
                Id = location.Id,
                Name = location.Name
            };
        }
    }
}
