using DisneyAppParte2.DataAccess.Repositories.UserRepository;
using DisneyAppParte2.Dtos.UserDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.Business.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public ActionResult Register(RegisterDto user)
        {
            return _userRepository.Register(user);
        }
        public ActionResult Login(LoginDto login)
        {
            return _userRepository.Login(login);
        }
    }
}
