﻿namespace MovieApp.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ConfirmedPassword { get; set; } = string.Empty;
    }
}
