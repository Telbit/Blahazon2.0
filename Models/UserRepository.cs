using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            if (user != null)
            {

                _context.Add(user);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("The given user is null!");
            }
        }

        public void Delete(long userId)
        {
            User user = _context.Find<User>(userId);
            if (user != null)
            {
                _context.Remove<User>(user);
                _context.SaveChanges();
            }
        }

        public User Get(long userId)
        {
            User user = _context.Users.Find(userId);
            if ( user != null)
            {
                return user;
            }
            else
            {
                throw new KeyNotFoundException("User not found with the given ID!");
            }
        }

        public void Update(User user)
        {
            var userToUpdate = _context.Users.Attach(user);
            userToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
