namespace BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsOnPromotion { get; set; }
        public bool HasFries { get; set; }
        public List<OrderBurger> OrderBurger { get; set; } = new List<OrderBurger>();

    }
}
