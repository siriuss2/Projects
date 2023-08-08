namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool HasFries { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
