using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.LocationViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name of the location")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Address of the location")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Opens At")]
        public string OpensAt { get; set; } = string.Empty;

        [Display(Name = "Closes At")]
        public string ClosesAt { get; set; } = string.Empty;
    }
}
