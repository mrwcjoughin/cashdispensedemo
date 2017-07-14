using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using cashdispensedemobackend.Models;

namespace cashdispensedemobackend.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private List<User> _userList = new List<User>() { new User() { UserId = 1, UserName = "richard@fnb.co.za", Password = "testmale" }, new User() { UserId = 2, UserName = "sally@fnb.co.za", Password = "testfemale" } };

        public UsersController()
        {
            //_userList.Add( new User() { UserId = 1, UserName = "richard@fnb.co.za", Password = "testmale" } );
            //_userList.Add( new User() { UserId = 2, UserName = "sally@fnb.co.za", Password = "testfemale" } );
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userList.Where(y => y.UserId == id).FirstOrDefault();
        }
    }
}
