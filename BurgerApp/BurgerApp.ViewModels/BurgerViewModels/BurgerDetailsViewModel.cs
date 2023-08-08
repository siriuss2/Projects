namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public bool IsOnPromotion { get; set; }

    }
}
