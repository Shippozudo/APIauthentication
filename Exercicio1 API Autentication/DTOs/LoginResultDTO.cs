using System;

namespace Exercicio1_API_Autentication.DTOs
{
    public class LoginResultDTO
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public UserLoginResultDTO User { get; set; }
    }

    public class UserLoginResultDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

    }
}
