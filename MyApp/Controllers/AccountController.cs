using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Helpers;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        //Example Users
        //TODO: Change by real users in DB
        private IEnumerable<User> Logins = new List<User>(){
            new User()
            {
                Id = 1,
                Email = "miguel@test.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User(){
                Id = 2,
                Email = "pepe@test.com",
                Name = "User1",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                // TODO :
                // Search a user in context with LINQ

                // We are searching one user through UserName && Password
                var searchUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName
                                  && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                // TODO: Change to searchUser
                // var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (searchUser is not null) // Other operation is (searchUser != null) while the equality operator is not overloaded
                {
                    // var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            // We are searching all Users
            // var searchUsers = _context.Users.ToList();
            var searchUsers = from user in _context.Users
                              select user;

            return Ok(searchUsers);
        }
    }
}
