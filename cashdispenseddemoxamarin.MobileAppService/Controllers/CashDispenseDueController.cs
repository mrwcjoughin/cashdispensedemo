using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cashdispenseddemoxamarin.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class CashDispenseDueController : Controller
    {
		// GET api/values/5
		[HttpGet]
		public IActionResult Get()
		{
            return Ok(new CashDispenseDue() { AmountOwed = CashDispenseDue.DefaultAmountOwed });
		}
    }
}
