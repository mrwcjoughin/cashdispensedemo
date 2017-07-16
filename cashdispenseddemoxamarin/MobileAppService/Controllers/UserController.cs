using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using cashdispenseddemoxamarin.MobileAppService.Models;

namespace cashdispenseddemoxamarin.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		//// GET: api/values
		//[HttpGet]
		//public IActionResult List()
		//{
		//	return Ok(_userRepository.GetAll());
		//}

        //public IActionResult Login([FromBody]User user)
		[HttpPost]
		public IActionResult Login([FromBody]User user)
		{
            User userLoginCheck = _userRepository.GetAll().Where((User arg) => arg.UserName == user.UserName && arg.Password == user.Password).FirstOrDefault();

            if (userLoginCheck != null)
            {
                if (userLoginCheck.Id != null)
                {
                    return Ok(userLoginCheck.Id);
                }
				else
				{
					return NotFound();
				}
            }
            else
            {
                return NotFound();
            }
		}

		//[HttpPost]
		//public IActionResult Create([FromBody]User user)
		//{
		//	try
		//	{
		//		if (user == null || !ModelState.IsValid)
		//		{
		//			return BadRequest("Invalid State");
		//		}

		//		_userRepository.Add(user);

		//	}
		//	catch (Exception)
		//	{
		//		return BadRequest("Error while creating");
		//	}
		//	return Ok(User);
		//}

		//[HttpPut]
		//public IActionResult Edit([FromBody] User user)
		//{
		//	try
		//	{
		//		if (user == null || !ModelState.IsValid)
		//		{
		//			return BadRequest("Invalid State");
		//		}
		//		_userRepository.Update(user);
		//	}
		//	catch (Exception)
		//	{
		//		return BadRequest("Error while creating");
		//	}
		//	return NoContent();
		//}

		//[HttpDelete("{Id}")]
		//public void Delete(string id)
		//{
		//	_userRepository.Remove(id);

		//}
    }
}