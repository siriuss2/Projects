﻿using BurgerApp.ViewModels.LocationViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationListViewModel>> GetAllLocations();
        Task<int> DeleteLocationById(int id);
        Task CreateLocation(LocationViewModel locationViewModel);
        Task<List<LocationsForDropdownViewModel>> GetLocationsForDropdown();
    }
}
