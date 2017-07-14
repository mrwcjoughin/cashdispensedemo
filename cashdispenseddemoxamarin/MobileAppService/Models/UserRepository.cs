using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace cashdispenseddemoxamarin.Models
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, User> _Users =
            new ConcurrentDictionary<string, User>();

        public UserRepository()
        {
            Add(new User { Id = Guid.NewGuid().ToString(), UserName = "richard@fnb.co.za", Password = "testmale" });
            Add(new User { Id = Guid.NewGuid().ToString(), UserName = "sally@fnb.co.za", Password = "testfemale" });
        }

        public User Get(string id)
        {
            return _Users[id];
        }

        public IEnumerable<User> GetAll()
        {
            return _Users.Values;
        }

        public void Add(User User)
        {
            User.Id = Guid.NewGuid().ToString();
            _Users[User.Id] = User;
        }

        public User Find(string id)
        {
            User User;
            _Users.TryGetValue(id, out User);

            return User;
        }

        public User Remove(string id)
        {
            User User;
            _Users.TryRemove(id, out User);

            return User;
        }

        public void Update(User User)
        {
            _Users[User.Id] = User;
        }
    }
}
