using DisneyAppParte2.Dtos.UserDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.Business.Services.UserService
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public ActionResult Register(RegisterDto user);
        public ActionResult Login(LoginDto login);
    }
}
