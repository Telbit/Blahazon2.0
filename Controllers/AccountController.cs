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
        private IUserRepository _users;
        private ICartRepository _carts;

        public AccountController(IUserRepository user, ICartRepository cart)
        {
            _users = user;
            _carts = cart;
        }


        [HttpPost("register")]
        public ActionResult Register(User user)
        {
            _users.Add(user);
            return NoContent();
        }

        [HttpPost("login")]
        public ActionResult<Boolean> Login(string userName, string password)
        {

            User loginUser = _users.Get(userName);
            if (loginUser != null)
            {
                if (loginUser.Password == password)
                {
                    HttpContext.Session.SetString("username", userName);
                    HttpContext.Session.SetInt32("userId", (int)loginUser.Id);
                    HttpContext.Session.SetInt32("cartId", (int)_carts.GetCartId(loginUser.Id));
                    

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

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return NoContent();
        }
    }
}
