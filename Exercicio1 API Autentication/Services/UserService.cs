using Exercicio1_API_Autentication.DTOs;
using Exercicio1_API_Autentication.Models;
using Exercicio1_API_Autentication.Repositorios;
using System;
using System.Collections.Generic;

namespace Exercicio1_API_Autentication.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly JWTTokenService _tokenService;

        public UserService(UserRepository repository, JWTTokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public UserDTO Create(User user)
        {
            var userExists = _repository.GetByUsername(user.Username);
            if (userExists != null)
                throw new Exception("O nome de usuário já esta sendo utilizado!!");

            var newUser = _repository.Create(user);

            return new UserDTO
            {
                Role = newUser.Role,
                Username = newUser.Username
            };

        }

        public IEnumerable<User> Get()
        {
            return _repository.Get();
        }

        public User Get(Guid id)
        {
            return _repository.Get(id);
        }

        public LoginResultDTO Login(string username, string password)
        {
            var loginResult = _repository.Login(username, password);

            if (loginResult.Error)
            {
                return new LoginResultDTO
                {
                    Success = false,
                    Errors = new string[] { $"Ocorreu um erro ao autenticar:{loginResult.Exception?.Message}" }
                };
            }

            var token = _tokenService.GenerateToken(loginResult.User);


            return new LoginResultDTO
            {
                Errors = null,
                Success = true,

                User = new UserLoginResultDTO
                {
                    Id = loginResult.User.Id,
                    Token = token,
                    Role = loginResult.User.Role,
                    Username = username
                }
            };
        }


    }
}
