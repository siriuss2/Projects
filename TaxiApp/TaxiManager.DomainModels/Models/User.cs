using TaxiManager.DomainModels.Enums;

namespace TaxiManager.DomainModels.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User()
        {
            
        }

        public User(string userName , string password , Role role)
        {
            Username = userName;
            Password = password;
            Role = role;
        }

        public override string Print()
        {
            return $"{Username} with the roll of {Role}";
        }
    }
}
