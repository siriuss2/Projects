using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Please enter full name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Please enter your address")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Is delivered")]
        public bool IsDelivered { get; set; }

        [Display(Name = "Select location")]
        public int LocationId { get; set; }

        [Display(Name = "Select burgers")]
        public List<int> BurgerId { get; set; }

    }
}
