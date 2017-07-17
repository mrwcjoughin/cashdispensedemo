using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public interface IUserRepository
    {
        void Add(User User);
        void Update(User User);
        User Remove(string key);
        User Get(string id);
        IEnumerable<User> GetAll();
    }
}
