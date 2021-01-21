using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(long userId);
        void Update(User user);
        User Get(long userId);
    }
}
