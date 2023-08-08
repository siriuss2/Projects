using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Burger Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Is Vegeterian")]
        public bool IsVegetarian { get; set; }

        [Display(Name = "Is Vegan")]
        public bool IsVegan { get; set; }

        [Display(Name = "Is On Promotion(-0.80$)")]
        public bool IsOnPromotion { get; set; }

        [Display(Name = "Fries(+0.30$)")]
        public bool HasFries { get; set; }
    }
}
