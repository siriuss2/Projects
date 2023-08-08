namespace BurgerApp.Domain.Models
{
    public class OrderBurger : BaseEntity
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Burger Burger { get; set; }
        public int BurgerId { get; set; }
    }
}
