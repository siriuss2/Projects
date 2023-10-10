namespace MovieApp.Services.Implementations
{
    using Microsoft.IdentityModel.Tokens;
    using MovieApp.DataAccess.Repositories.Interfaces;
    using MovieApp.Domain.Domain;
    using MovieApp.DTOs.UserDTOs;
    using MovieApp.Services.Interfaces;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using XSystem.Security.Cryptography;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public async Task<string> LoginUser(LoginUserDTO loginUserDTO)
        {
            if (string.IsNullOrEmpty(loginUserDTO.Username) || string.IsNullOrEmpty(loginUserDTO.Password))
                throw new Exception("Username and password are required");

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(loginUserDTO.Password);
            byte[] hashBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hash = Encoding.ASCII.GetString(hashBytes);

            User user = await _userRepository.LoginUser(loginUserDTO.Username, hash);

            if (user == null)
                throw new Exception("User not found!");

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("Our very secret code");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("userFullName", $"{user.FirstName} {user.LastName}"),
                    })
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterUserDTO registerUserDTO)
        {
            await ValidateUser(registerUserDTO);

            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDTO.Password);
            byte[] hashBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);
            string hash = Encoding.ASCII.GetString(hashBytes);

            User user = new User()
            {
                FirstName = registerUserDTO.FirstName,
                LastName = registerUserDTO.LastName,
                Username = registerUserDTO.Username,
                Age = registerUserDTO.Age,
                Password = hash
            };

            await _userRepository.CreateAsync(user);
        }

        private async Task ValidateUser(RegisterUserDTO user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmedPassword))
                throw new Exception("Username and password are required!");

            if (user.Username.Length > 30)
                throw new Exception("Username max length is 30 characters!");

            if (!string.IsNullOrEmpty(user.FirstName) && user.FirstName.Length > 50)
                throw new Exception("Max length for FirstName field is 50 characters");

            if (!string.IsNullOrEmpty(user.LastName) && user.LastName.Length > 50)
                throw new Exception("Max length for LastName field is 50 characters");

            if (user.Password != user.ConfirmedPassword)
                throw new Exception("Passwords do not match.");

            var userDb = await _userRepository.GetUserByUsername(user.Username);

            if (userDb != null)
                throw new Exception($"The username {user.Username} is already in use.");
        }
    }
}
