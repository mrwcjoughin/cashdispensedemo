using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using cashdispenseddemoxamarin.Models;

namespace cashdispenseddemoxamarin.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository UserRepository)
		{
			_userRepository = UserRepository;
		}

		// GET: api/values
		[HttpGet]
		public IActionResult List()
		{
			return Ok(_userRepository.GetAll());
		}

		[HttpGet("{Id}")]
		public User GetUser(string id)
		{
			User user = _userRepository.Get(id);
			return user;
		}

		[HttpPost]
		public IActionResult Create([FromBody]User User)
		{
			try
			{
				if (User == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}

				_userRepository.Add(User);

			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return Ok(User);
		}

		[HttpPut]
		public IActionResult Edit([FromBody] User User)
		{
			try
			{
				if (User == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}
				_userRepository.Update(User);
			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return NoContent();
		}

		[HttpDelete("{Id}")]
		public void Delete(string id)
		{
			_userRepository.Remove(id);

		}
    }
}
