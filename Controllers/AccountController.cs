using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blahazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Blahazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _users;
        private readonly ICartRepository _carts;
        private readonly AppDbContext _context;

        public AccountController(IUserRepository user, ICartRepository cart, AppDbContext context)
        {
            _users = user;
            _carts = cart;
            _context = context;
        }


        [HttpPost("register")]
        public ActionResult<Int32> Register(User user)
        {
            foreach (User currUser in _context.Users)
            {
                if (currUser.Email == user.Email)
                {
                    return 156;
                }
                else if (currUser.Username == user.Username)
                {

                    return 158;
                }
            }
            _users.Add(user);
            return 160;
        }

        [HttpPost("login")]
        public ActionResult<Boolean> Login(User user)
        {
            User matchingUser = _users.Get(user.Username);
            string userName = user.Username;
            string password = user.Password;
            if (user.Username != null && user.Password != null)
            { 
                if (matchingUser.Password == password)
                {
                    HttpContext.Session.SetString("username", userName);
                    HttpContext.Session.SetInt32("userId", (int)matchingUser.Id);
                    HttpContext.Session.SetInt32("cartId", (int)_carts.GetCartId(matchingUser.Id));
                    

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return NoContent();
        }

        [HttpGet("issession")]
        public ActionResult<Boolean> isLoggedIn()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
