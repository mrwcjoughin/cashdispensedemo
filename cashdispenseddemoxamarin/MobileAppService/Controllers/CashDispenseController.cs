using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using cashdispenseddemoxamarin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cashdispensedemobackend.Controllers
{
    [Route("api/[controller]")]
    public class CashDispenseController : Controller
    {
        private Cash _defaultAmountOwed = new Cash() {  Denomination = "R", Number = 25.50m };

		// GET api/values/5
		[HttpGet]
		public Cash Get()
		{
			return _defaultAmountOwed;
		}

        // GET api/values/cash
        [HttpGet("{cash}")]
        public IActionResult Get(Cash cash)
        {
            if (cash.Number < _defaultAmountOwed.Number)
            {
                return BadRequest("The amount you are paying is less than the amount owed");
            }

			CashDispenseResult cashDispenseResult = new CashDispenseResult();

            var difference = cash.Number - _defaultAmountOwed.Number;

            var runningDifference = difference;

            if (runningDifference > 0)
            {
                runningDifference = Calc(100.00m, "R", cashDispenseResult, runningDifference);
            }

            if (runningDifference > 0)
            {
                runningDifference = Calc(50.00m, "R", cashDispenseResult, runningDifference);
            }

            if (runningDifference > 0)
            {
                runningDifference = Calc(20.00m, "R", cashDispenseResult, runningDifference);
            }

            if (runningDifference > 0)
            {
				runningDifference = Calc(10.00m, "R", cashDispenseResult, runningDifference);
            }

			if (runningDifference > 0)
			{
                runningDifference = Calc(5.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
            {
                runningDifference = Calc(2.00m, "R", cashDispenseResult, runningDifference);
            }

			if (runningDifference > 0)
			{
				runningDifference = Calc(1.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.50m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.20m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.25m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.10m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.05m, "cents", cashDispenseResult, runningDifference);
			}

            return Ok(cashDispenseResult);
        }

        private static decimal Calc(decimal number, string denomination, CashDispenseResult cashDispenseResult, decimal runningDifference)
        {
            var randNoteResults = runningDifference / number;

            if (randNoteResults >= 1)
            {
                Cash randNotes = new Cash();
                randNotes.Denomination = denomination;
                randNotes.Number = Math.Abs(randNoteResults);

                cashDispenseResult.ChangeResults.Add(randNotes);

                runningDifference -= randNotes.Number * number;
            }

            return runningDifference;
        }
    }
}
