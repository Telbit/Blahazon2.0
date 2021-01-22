using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blahazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Blahazon.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _users;

        public UserController(IUserRepository users)
        {
            _users = users;
        }

        

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _users.Add(user);
            return NoContent();
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(long userId)
        {
            User user = _users.Get(userId);
            if (user != null)
            {
                return user;
            }
            else
            {
                return NotFound($"User not found with the {userId} : user ID");
            }
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(long userId)
        {
            User user = _users.Get(userId);
            if ( user != null)
            {
                _users.Delete(userId);
                return NoContent();

            }
            else
            {
                return NotFound();
            }
        }
    }
}
