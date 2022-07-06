using DisneyAppParte2.Dtos.UserDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.DataAccess.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public ActionResult Register(RegisterDto user);
        public ActionResult Login(LoginDto login);
        public bool UserExist(string username, string email);
    }
}
