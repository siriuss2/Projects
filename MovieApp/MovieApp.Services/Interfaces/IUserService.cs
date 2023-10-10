namespace MovieApp.Services.Interfaces
{
    using MovieApp.DTOs.UserDTOs;

    public interface IUserService
    {
        Task RegisterUser(RegisterUserDTO registerUserDTO);
        Task<string> LoginUser(LoginUserDTO loginUserDTO);
    }
}
