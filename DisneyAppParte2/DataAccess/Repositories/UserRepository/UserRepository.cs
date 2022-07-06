using DisneyAppParte2.Business.Services.TokenService;
using DisneyAppParte2.DataAccess.Data;
using DisneyAppParte2.Dtos.EmailDtos;
using DisneyAppParte2.Dtos.UserDtos;
using DisneyAppParte2.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Security.Cryptography;
using System.Text;

namespace DisneyAppParte2.DataAccess.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DisneyAppDbContext _context;
        private readonly ITokenService _tokenservice;
        private readonly IEmailService _emailService;
        public UserRepository(DisneyAppDbContext context, ITokenService tokenService, IEmailService emailService)
        {
            _context = context;
            _tokenservice = tokenService;
            _emailService = emailService;
        }
        public List<User> GetUsers()
        {
            return _context.User.ToList();
        }
        public ActionResult Register(RegisterDto user)
        {
            if (!UserExist(user.Username, user.Email))
                return new NotFoundObjectResult("User or email already taken");

            using var hmac = new HMACSHA512();
            var newUser = new User()
            {
                UserName = user.Username,
                Email = user.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };
            _context.User.Add(newUser);
            _context.SaveChanges();

            var token = _tokenservice.CreateToken(newUser);
            var userDto = new UserDto()
            {
                UserName = user.Username,
                Email = user.Email,
                Token = token
            };
            var email = new EmailDto()
            {
                To = user.Email,
                Subject = "Welcome",
                Body = "<h1>Welcome to DisneyApiApp<h1><br><p>Your token is: <p>" + token,
            };

            _emailService.SendEmail(email);
            return new OkObjectResult(userDto);
        }
        public ActionResult Login(LoginDto login)
        {
            var user = _context.User.SingleOrDefault(u => u.Email == login.Email);
            if (user == null) return new NotFoundObjectResult("Username or password incorrect");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) throw new ArgumentException("Username or password incorrect");
            }
            var token = _tokenservice.CreateToken(user);
            var userDto = new UserDto()
            {
                UserName = login.Username,
                Email = login.Email,
                Token = token
            };
            var email = new EmailDto()
            {
                To = user.Email,
                Subject = "Welcome",
                Body = "<h1>Welcome to DisneyApiApp<h1><p>Your token is: <p>" + token,
            };

            _emailService.SendEmail(email);
            return new OkObjectResult(userDto);
        }
        public bool UserExist(string username, string email)
        {
            var foundUser = _context.User.Any(u => u.UserName == username || u.Email == email);
            if (foundUser == true)
                return false;
            return true;
        }
    }
}
